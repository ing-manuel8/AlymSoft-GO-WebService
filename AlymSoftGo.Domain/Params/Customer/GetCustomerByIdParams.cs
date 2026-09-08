using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AlymSoftGo.Domain.Params.Customer
{
    /// <summary>
    /// Parámetros para consultar el detalle de un cliente por ID
    /// </summary>
    public class GetCustomerByIdParams
    {
        [JsonProperty("@idCliente")]
        [Required]
        public int CustomerId { get; set; }

        [JsonProperty("@idEmpresa")]
        [Required]
        public int CompanyId { get; set; }
    }
}
