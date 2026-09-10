namespace AlymSoftGo.Domain.DTOs.Client
{
    public class ClientModifierOptionDto
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public decimal ExtraPrice { get; set; }
    }
}
