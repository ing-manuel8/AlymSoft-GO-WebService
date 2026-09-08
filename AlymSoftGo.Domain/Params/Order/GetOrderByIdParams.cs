using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AlymSoftGo.Domain.Params.Order
{
    /// <summary>
    /// Parámetros para consultar el detalle de un pedido por ID
    /// </summary>
    public class GetOrderByIdParams
    {
        [JsonProperty("@idPedido")]
        [Required]
        public int OrderId { get; set; }
    }
}
