using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AlymSoftGo.Domain.DTOs
{
    public class OrderListDto
    {
        public int Id { get; set; }
        public string Folio { get; set; } = string.Empty;
        public int CompanyId { get; set; }
        public int? BranchId { get; set; }
        public string? BranchName { get; set; }
        public int? CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
        public string? CustomerEmail { get; set; }
        public int DeliveryTypeId { get; set; }
        public string DeliveryTypeName { get; set; } = string.Empty;
        public string DeliveryTypeCode { get; set; } = string.Empty;
        public string? DeliveryAddress { get; set; }
        public string? OrderNotes { get; set; }
        public int PaymentMethodId { get; set; }
        public string PaymentMethodName { get; set; } = string.Empty;
        public string PaymentMethodCode { get; set; } = string.Empty;
        public int StatusId { get; set; }
        public string StatusName { get; set; } = string.Empty;
        public string StatusCode { get; set; } = string.Empty;
        public decimal Subtotal { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsPaid { get; set; }
        public DateTime? PaidDate { get; set; }
    }

    public class OrderDetailDto
    {
        public int Id { get; set; }
        public string Folio { get; set; } = string.Empty;
        public int CompanyId { get; set; }
        public int? BranchId { get; set; }
        public string? BranchName { get; set; }
        public int? CustomerId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
        public string? CustomerEmail { get; set; }
        public int DeliveryTypeId { get; set; }
        public string DeliveryTypeName { get; set; } = string.Empty;
        public string DeliveryTypeCode { get; set; } = string.Empty;
        public string? DeliveryAddress { get; set; }
        public string? OrderNotes { get; set; }
        public int PaymentMethodId { get; set; }
        public string PaymentMethodName { get; set; } = string.Empty;
        public string PaymentMethodCode { get; set; } = string.Empty;
        public int StatusId { get; set; }
        public string StatusName { get; set; } = string.Empty;
        public string StatusCode { get; set; } = string.Empty;
        public decimal Subtotal { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsPaid { get; set; }
        public DateTime? PaidDate { get; set; }
        public List<OrderItemDto> Items { get; set; } = new();
    }

    public class OrderItemDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string? Sku { get; set; }
        public string? Barcode { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal Total { get; set; }
        public string? SpecialInstructions { get; set; }
    }

    public class CreateOrderItemRequestDto
    {
        [JsonProperty("idProducto")]
        [Required]
        public int ProductId { get; set; }

        [JsonProperty("vProductoNombre")]
        public string ProductName { get; set; } = string.Empty;

        [JsonProperty("vNombreProducto")]
        public string? LegacyProductName
        {
            get => ProductName;
            set { if (string.IsNullOrWhiteSpace(ProductName) && !string.IsNullOrWhiteSpace(value)) ProductName = value; }
        }

        [JsonProperty("vSKU")]
        public string? Sku { get; set; }

        [JsonProperty("vCodigoBarras")]
        public string? Barcode { get; set; }

        [JsonProperty("idCatTipoUnidad")]
        public int? UnitTypeId { get; set; } = 1;

        [JsonProperty("dPrecioUnitario")]
        [Range(0, double.MaxValue, ErrorMessage = "El precio unitario no puede ser negativo")]
        public decimal UnitPrice { get; set; }

        [JsonProperty("dCantidad")]
        [Range(0.001, double.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0")]
        public decimal Quantity { get; set; }

        [JsonProperty("dImporteTotal")]
        [Range(0, double.MaxValue, ErrorMessage = "El importe total no puede ser negativo")]
        public decimal Total { get; set; }

        [JsonProperty("vInstruccionesEspeciales")]
        public string? SpecialInstructions { get; set; }
    }

    public class CreateOrderRequestDto
    {
        public int? CompanyId { get; set; }
        public int? BranchId { get; set; }
        public int? CustomerId { get; set; }

        [Required(ErrorMessage = "El nombre del cliente es obligatorio")]
        public string CustomerName { get; set; } = string.Empty;

        [Required(ErrorMessage = "El teléfono del cliente es obligatorio")]
        public string CustomerPhone { get; set; } = string.Empty;

        public string? CustomerEmail { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Tipo de entrega no válido")]
        public int DeliveryTypeId { get; set; } = 1; // 1: Recoger, 2: Domicilio

        public string? BranchName { get; set; }
        public string? DeliveryAddress { get; set; }
        public string? OrderNotes { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Medio de pago no válido")]
        public int PaymentMethodId { get; set; } = 1;

        public decimal Subtotal { get; set; }
        public decimal ShippingCost { get; set; }
        public decimal Discount { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "El total no puede ser negativo")]
        public decimal Total { get; set; }

        public bool IsPaid { get; set; }

        [Required(ErrorMessage = "Las partidas del pedido son obligatorias")]
        [MinLength(1, ErrorMessage = "Debe incluir al menos un producto en el pedido")]
        public List<CreateOrderItemRequestDto> Items { get; set; } = new();

        public string? User { get; set; }
    }

    public class UpdateOrderStatusRequestDto
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Estado de pedido no válido")]
        public int StatusId { get; set; }

        public string? Reason { get; set; }
        public string? User { get; set; }
    }

    public class CreatedOrderResultDto
    {
        public int Id { get; set; }
        public string Folio { get; set; } = string.Empty;
    }

    public class UpdatedOrderStatusResultDto
    {
        public int Id { get; set; }
        public int StatusId { get; set; }
    }
}
