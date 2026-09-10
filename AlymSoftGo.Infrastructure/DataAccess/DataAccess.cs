using System.Data;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using AlymSoftGo.Domain.Common;
using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.Exceptions;
using AlymSoftGo.Domain.Interfaces.Persistence;

namespace AlymSoftGo.Infrastructure.DataAccess
{
    public class DataAccess : IDataAccess
    {
        private readonly string _connectionString;
        private readonly ILogger<DataAccess> _logger;

        public DataAccess(IConfiguration configuration, ILogger<DataAccess> logger)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnectionSQL")
                ?? throw new ArgumentNullException(nameof(configuration), "Connection string 'DefaultConnectionSQL' not found.");
            _logger = logger;
        }

        public async Task ExecuteSpAsync(string spName, Dictionary<string, object>? @params = null)
        {
            await ExecuteSpAsync<EmptyDto>(spName, @params);
        }

        public async Task<TData> ExecuteSpAsync<TData>(string spName, Dictionary<string, object>? @params = null) where TData : class, new()
        {
            var (statusInfo, allDataSets) = await ExecuteSpInternalAsync(spName, @params);
            var mappedCode = MapSpStatusToEnum(statusInfo.ResponseCode, statusInfo.ErrorDescription);

            // Validaciones de negocio (ResponseType = 3) o Errores inesperados (ResponseType = 2)
            if (statusInfo.ResponseType != 1 || mappedCode != ResponseCode.Ok)
            {
                ThrowAppropriateException(mappedCode, statusInfo, spName);
            }

            if (typeof(TData) == typeof(EmptyDto))
            {
                return (new EmptyDto() as TData)!;
            }

            if (allDataSets.Count == 0)
            {
                return new TData();
            }

            try
            {
                var json = JsonConvert.SerializeObject(allDataSets);
                var jsonObject = JObject.Parse(json);
                var table1Json = jsonObject.ContainsKey("table1") ? jsonObject["table1"] as JArray : null;

                // Caso 1: TData es directamente una colección o arreglo (ej. List<ProductDto>)
                if (typeof(TData).IsArray || (typeof(System.Collections.IEnumerable).IsAssignableFrom(typeof(TData)) && typeof(TData) != typeof(string)))
                {
                    return (table1Json?.ToObject<TData>()) ?? new TData();
                }

                // Caso 2: TData es un objeto/DTO con propiedades
                var scalarProps = typeof(TData).GetProperties()
                    .Where(p => (p.PropertyType.IsValueType || p.PropertyType == typeof(string)) && p.CanWrite)
                    .ToList();

                var listProps = typeof(TData).GetProperties()
                    .Where(p => typeof(System.Collections.IEnumerable).IsAssignableFrom(p.PropertyType) 
                             && p.PropertyType != typeof(string) 
                             && p.CanWrite)
                    .ToList();

                TData? data;

                if (scalarProps.Count > 0)
                {
                    // table1 puebla los campos principales del objeto
                    data = (table1Json != null && table1Json.Count > 0)
                        ? table1Json[0].ToObject<TData>()
                        : new TData();

                    // table2, table3, table4, table5, table6... pueblan las listas hijas en orden
                    for (int i = 2; i <= allDataSets.Count; i++)
                    {
                        var tableKey = $"table{i}";
                        if (allDataSets.ContainsKey(tableKey))
                        {
                            var childTableJson = jsonObject[tableKey] as JArray;
                            int propIndex = i - 2;
                            if (propIndex < listProps.Count && childTableJson != null)
                            {
                                var targetProp = listProps[propIndex];
                                var childList = childTableJson.ToObject(targetProp.PropertyType);
                                targetProp.SetValue(data, childList);
                            }
                        }
                    }
                }
                else
                {
                    // TData es un contenedor compuesto de múltiples listas
                    data = new TData();

                    // table1, table2, table3, table4... pueblan las colecciones hijas en orden
                    for (int i = 1; i <= allDataSets.Count; i++)
                    {
                        var tableKey = $"table{i}";
                        if (allDataSets.ContainsKey(tableKey))
                        {
                            var childTableJson = jsonObject[tableKey] as JArray;
                            int propIndex = i - 1;
                            if (propIndex < listProps.Count && childTableJson != null)
                            {
                                var targetProp = listProps[propIndex];
                                var childList = childTableJson.ToObject(targetProp.PropertyType);
                                targetProp.SetValue(data, childList);
                            }
                        }
                    }
                }

                return data ?? new TData();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error processing SP response: {SpName}", spName);
                throw new InvalidOperationException($"Failed to deserialize response from SP {spName}. Error: {ex.Message}", ex);
            }
        }

        private async Task<(StatusInfo Status, Dictionary<string, List<Dictionary<string, object>>> DataSets)> ExecuteSpInternalAsync(
            string spName, Dictionary<string, object>? @params)
        {
            using var connection = new SqlConnection(_connectionString);
            using var command = new SqlCommand(spName, connection)
            {
                CommandType = CommandType.StoredProcedure,
                CommandTimeout = 60
            };

            if (@params != null)
            {
                foreach (var param in @params)
                {
                    var paramName = param.Key.StartsWith("@") ? param.Key : $"@{param.Key}";
                    command.Parameters.AddWithValue(paramName, param.Value ?? DBNull.Value);
                }
            }

            await connection.OpenAsync();
            using var reader = await command.ExecuteReaderAsync();

            var statusInfo = new StatusInfo();
            var allDataSets = new Dictionary<string, List<Dictionary<string, object>>>();

            // 1er SELECT: ResponseType y ResponseCode
            if (await reader.ReadAsync())
            {
                statusInfo.ResponseType = Convert.ToInt32(reader["ResponseType"]);
                statusInfo.ResponseCode = reader["ResponseCode"].ToString()!;
                
                if (HasColumn(reader, "ErrorTitle") && reader["ErrorTitle"] != DBNull.Value)
                    statusInfo.ErrorTitle = reader["ErrorTitle"].ToString();
                
                if (HasColumn(reader, "ErrorDescription") && reader["ErrorDescription"] != DBNull.Value)
                    statusInfo.ErrorDescription = reader["ErrorDescription"].ToString();
            }

            // 2do SELECT y posteriores: Payload de datos
            int tableIndex = 1;
            while (await reader.NextResultAsync())
            {
                var tableData = new List<Dictionary<string, object>>();
                while (await reader.ReadAsync())
                {
                    var row = new Dictionary<string, object>();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        var columnName = reader.GetName(i);
                        var value = reader.IsDBNull(i) ? null! : reader.GetValue(i);
                        row[columnName] = value;
                    }
                    tableData.Add(row);
                }
                allDataSets[$"table{tableIndex}"] = tableData;
                tableIndex++;
            }

            return (statusInfo, allDataSets);
        }

        private static bool HasColumn(SqlDataReader reader, string columnName)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Equals(columnName, StringComparison.OrdinalIgnoreCase))
                    return true;
            }
            return false;
        }

        private static ResponseCode MapSpStatusToEnum(string responseCodeStr, string? errorDesc = null)
        {
            if (string.IsNullOrWhiteSpace(responseCodeStr) || responseCodeStr.Equals("Ok", StringComparison.OrdinalIgnoreCase))
                return ResponseCode.Ok;

            var cleanedCode = responseCodeStr.Replace("_", "");
            if (Enum.TryParse<ResponseCode>(cleanedCode, true, out var parsed))
                return parsed;

            if (!string.IsNullOrWhiteSpace(errorDesc))
            {
                var cleanedDesc = errorDesc.Replace("_", "");
                if (Enum.TryParse<ResponseCode>(cleanedDesc, true, out var parsedDesc))
                    return parsedDesc;
            }

            return ResponseCode.ValidationFailed;
        }

        private static void ThrowAppropriateException(ResponseCode code, StatusInfo status, string spName)
        {
            if (status.ResponseType == 2)
            {
                throw new SPUnexpectedException(
                    status.ErrorTitle ?? "DATABASE_ERROR",
                    status.ErrorDescription ?? $"Unexpected error in {spName}",
                    status.ResponseCode
                );
            }

            var errorCode = !string.IsNullOrEmpty(status.ErrorDescription) && !status.ErrorDescription.Contains(' ')
                ? status.ErrorDescription
                : status.ResponseCode;

            var errorMessage = !string.IsNullOrEmpty(status.ErrorDescription) ? status.ErrorDescription : status.ResponseCode;
            throw new SPBusinessException(code, errorCode, errorMessage, status.ResponseType);
        }

        private class StatusInfo
        {
            public int ResponseType { get; set; } = 1;
            public string ResponseCode { get; set; } = "Ok";
            public string? ErrorTitle { get; set; }
            public string? ErrorDescription { get; set; }
        }
    }
}
