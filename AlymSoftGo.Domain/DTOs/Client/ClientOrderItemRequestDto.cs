using System.Collections.Generic;

namespace AlymSoftGo.Domain.DTOs.Client
{
    public class ClientOrderItemRequestDto
    {
        public int? ProductId { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public string? Sku { get; set; }
        public string? Barcode { get; set; }
        public int? UnitTypeId { get; set; } = 1;
        public decimal UnitPrice { get; set; }
        public decimal Quantity { get; set; }
        public decimal Total { get; set; }
        public string? SpecialInstructions { get; set; }
        public List<ClientOrderItemModifierRequestDto> Modifiers { get; set; } = new();
    }
}
