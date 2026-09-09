using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AlymSoftGo.Domain.Params.Branch
{
    /// <summary>
    /// Parámetros para crear o actualizar una sucursal
    /// </summary>
    public class SaveBranchParams
    {
        [JsonProperty("@idSucursal")]
        public int? BranchId { get; set; }

        [JsonProperty("@idEmpresa")]
        [Required]
        public int CompanyId { get; set; }

        [JsonProperty("@vNombre")]
        [Required]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("@vDireccion")]
        public string? Address { get; set; }

        [JsonProperty("@vTelefono")]
        public string? Phone { get; set; }

        [JsonProperty("@vEmailContacto")]
        public string? ContactEmail { get; set; }

        [JsonProperty("@vHorarioAtencion")]
        public string? OperatingHours { get; set; }

        [JsonProperty("@bPermiteEntregaDomicilio")]
        public bool AllowsDelivery { get; set; } = true;

        [JsonProperty("@bPermiteRecogerSucursal")]
        public bool AllowsPickup { get; set; } = true;

        [JsonProperty("@vTimeZone")]
        public string TimeZone { get; set; } = "Central Standard Time (Mexico)";

        [JsonProperty("@vTimeZoneIANA")]
        public string TimeZoneIANA { get; set; } = "America/Mexico_City";

        [JsonProperty("@vCurrency")]
        public string? Currency { get; set; }

        [JsonProperty("@vCulture")]
        public string? Culture { get; set; }

        [JsonProperty("@vUser")]
        [Required]
        public string User { get; set; } = "SYSTEM";
    }
}
