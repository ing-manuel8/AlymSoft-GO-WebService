using System.Collections.Generic;

namespace AlymSoftGo.Domain.DTOs.Client
{
    public class ClientCreateOrderRequestDto
    {
        public string StoreSlug { get; set; } = string.Empty;
        public int? BranchId { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
        public string? CustomerEmail { get; set; }
        public int FulfillmentType { get; set; } = 1; // 1: Domicilio, 2: Recoger
        public string? DeliveryAddress { get; set; }
        public string? Comments { get; set; }
        public int PaymentMethodId { get; set; } = 1; // 1: Efectivo, 2: Tarjeta, 3: Transferencia
        public decimal Subtotal { get; set; }
        public decimal DeliveryFee { get; set; }
        public decimal Discount { get; set; }
        public decimal Total { get; set; }
        public List<ClientOrderItemRequestDto> Items { get; set; } = new();
    }
}
