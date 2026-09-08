using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AlymSoftGo.Domain.Params.Order
{
    /// <summary>
    /// Parámetros para registrar un nuevo pedido en el sistema
    /// </summary>
    public class CreateOrderParams
    {
        [JsonProperty("@idEmpresa")]
        [Required]
        public int CompanyId { get; set; }

        [JsonProperty("@idSucursal")]
        public int? BranchId { get; set; }

        [JsonProperty("@idCliente")]
        public int? CustomerId { get; set; }

        [JsonProperty("@vClienteNombre")]
        [Required]
        public string CustomerName { get; set; } = string.Empty;

        [JsonProperty("@vClienteTelefono")]
        [Required]
        public string CustomerPhone { get; set; } = string.Empty;

        [JsonProperty("@vClienteEmail")]
        public string? CustomerEmail { get; set; }

        [JsonProperty("@idCatTipoEntrega")]
        public int DeliveryTypeId { get; set; } = 1;

        [JsonProperty("@vSucursalNombre")]
        public string? BranchName { get; set; }

        [JsonProperty("@vDireccionEntrega")]
        public string? DeliveryAddress { get; set; }

        [JsonProperty("@vComentariosPedido")]
        public string? OrderNotes { get; set; }

        [JsonProperty("@idCatMedioPago")]
        public int PaymentMethodId { get; set; } = 1;

        [JsonProperty("@dSubtotal")]
        public decimal Subtotal { get; set; }

        [JsonProperty("@dCostoEnvio")]
        public decimal ShippingCost { get; set; } = 0;

        [JsonProperty("@dDescuento")]
        public decimal Discount { get; set; } = 0;

        [JsonProperty("@dTotal")]
        public decimal Total { get; set; }

        [JsonProperty("@bEstaPagado")]
        public bool IsPaid { get; set; } = false;

        [JsonProperty("@vItemsJSON")]
        [Required]
        public string ItemsJson { get; set; } = "[]";

        [JsonProperty("@vUser")]
        [Required]
        public string User { get; set; } = "SYSTEM";
    }
}
