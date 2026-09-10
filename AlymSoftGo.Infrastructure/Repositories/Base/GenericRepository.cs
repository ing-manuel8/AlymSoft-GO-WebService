using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.Interfaces.Persistence;

namespace AlymSoftGo.Infrastructure.Repositories.Base
{
    public abstract class GenericRepository
    {
        private static readonly string[] RepositorySuffixes = ["Repository", "Repo"];
        protected readonly IDataAccess _dataAccess;
        private string? _entityName;
        protected virtual string DatabaseName => "AlymSoftGo";

        protected GenericRepository(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
        }

        protected string EntityName
        {
            get
            {
                _entityName ??= RemoveRepositorySuffix(GetType().Name);
                return _entityName;
            }
        }

        private static string RemoveRepositorySuffix(string className)
        {
            foreach (string suffix in RepositorySuffixes)
            {
                if (className.EndsWith(suffix, StringComparison.OrdinalIgnoreCase))
                    return className[..^suffix.Length];
            }
            return className;
        }

        protected async Task ResolveSpAsync(object @params, [CallerMemberName] string methodName = "")
            => await ResolveSpAsync<EmptyDto>(@params, methodName);

        protected async Task ResolveSpAsync(Dictionary<string, object>? @params = null, [CallerMemberName] string methodName = "")
            => await ResolveSpAsync<EmptyDto>(@params, methodName);

        protected async Task<TData> ResolveSpAsync<TData>(object @params, [CallerMemberName] string methodName = "") where TData : class, new()
        {
            var parameters = JObject
                .FromObject(@params, new JsonSerializer { NullValueHandling = NullValueHandling.Ignore })
                .ToObject<Dictionary<string, object>>();

            return await ResolveSpAsync<TData>(parameters, methodName);
        }

        protected async Task<TData> ResolveSpAsync<TData>(Dictionary<string, object>? @params = null, [CallerMemberName] string methodName = "") where TData : class, new()
            => await _dataAccess.ExecuteSpAsync<TData>(Sp(methodName), @params);

        protected string Sp(string methodName) => $"spr_{DatabaseName}_{EntityName}_{methodName.Replace("Async", string.Empty)}";
    }
}
