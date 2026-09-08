using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AlymSoftGo.Domain.Params.Customer
{
    /// <summary>
    /// Parámetros para dar de baja lógica a un cliente
    /// </summary>
    public class DeleteCustomerParams
    {
        [JsonProperty("@idCliente")]
        [Required]
        public int CustomerId { get; set; }

        [JsonProperty("@idEmpresa")]
        [Required]
        public int CompanyId { get; set; }

        [JsonProperty("@vUser")]
        [Required]
        public string User { get; set; } = "SYSTEM";
    }
}
