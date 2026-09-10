namespace AlymSoftGo.Domain.DTOs.Client
{
    public class ClientBranchDto
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Slug { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Schedule { get; set; }
        public bool AllowsDelivery { get; set; } = true;
        public bool AllowsPickup { get; set; } = true;
    }
}
