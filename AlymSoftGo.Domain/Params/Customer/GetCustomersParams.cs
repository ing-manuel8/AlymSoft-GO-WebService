using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AlymSoftGo.Domain.Params.Customer
{
    /// <summary>
    /// Parámetros para listar clientes por empresa con búsqueda opcional
    /// </summary>
    public class GetCustomersParams
    {
        [JsonProperty("@idEmpresa")]
        [Required]
        public int CompanyId { get; set; }

        [JsonProperty("@vSearch")]
        public string? Search { get; set; }
    }
}
