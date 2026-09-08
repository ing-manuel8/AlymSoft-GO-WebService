using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AlymSoftGo.Domain.Params.Order
{
    /// <summary>
    /// Parámetros para actualizar el estado de un pedido y registrar su transición
    /// </summary>
    public class UpdateOrderStatusParams
    {
        [JsonProperty("@idPedido")]
        [Required]
        public int OrderId { get; set; }

        [JsonProperty("@idCatEstadoNuevo")]
        [Required]
        public int NewStatusId { get; set; }

        [JsonProperty("@vMotivoCambio")]
        public string? Reason { get; set; }

        [JsonProperty("@vUser")]
        [Required]
        public string User { get; set; } = "SYSTEM";
    }
}
