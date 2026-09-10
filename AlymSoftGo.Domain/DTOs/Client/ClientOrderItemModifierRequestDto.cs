namespace AlymSoftGo.Domain.DTOs.Client
{
    public class ClientOrderItemModifierRequestDto
    {
        public int? ModifierId { get; set; }
        public string GroupName { get; set; } = string.Empty;
        public string ModifierName { get; set; } = string.Empty;
        public decimal ExtraPrice { get; set; }
        public int Quantity { get; set; } = 1;
        public string Section { get; set; } = "TODO";
    }
}
