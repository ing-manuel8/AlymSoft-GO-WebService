using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AlymSoftGo.Domain.Params.Customer
{
    /// <summary>
    /// Parámetros para crear o actualizar un cliente
    /// </summary>
    public class SaveCustomerParams
    {
        [JsonProperty("@idCliente")]
        public int? CustomerId { get; set; }

        [JsonProperty("@idEmpresa")]
        [Required]
        public int CompanyId { get; set; }

        [JsonProperty("@vNombreCompleto")]
        [Required]
        public string FullName { get; set; } = string.Empty;

        [JsonProperty("@vTelefono")]
        [Required]
        public string Phone { get; set; } = string.Empty;

        [JsonProperty("@vDireccionPredeterminada")]
        public string? DefaultAddress { get; set; }

        [JsonProperty("@vNotas")]
        public string? Notes { get; set; }

        [JsonProperty("@vUser")]
        [Required]
        public string User { get; set; } = "SYSTEM";
    }
}
