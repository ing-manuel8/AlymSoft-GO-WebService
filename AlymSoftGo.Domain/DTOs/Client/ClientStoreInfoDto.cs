using System.Collections.Generic;

namespace AlymSoftGo.Domain.DTOs.Client
{
    public class ClientStoreInfoDto
    {
        public int CompanyId { get; set; }
        public string StoreName { get; set; } = string.Empty;
        public string StoreSlug { get; set; } = string.Empty;
        public string? LogoUrl { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; } = string.Empty;
        public string? BranchSlug { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string Schedule { get; set; } = string.Empty;
        public string Currency { get; set; } = "MXN";
        public string Culture { get; set; } = "es-MX";
        public decimal BaseDeliveryFee { get; set; }
        public bool AllowsDelivery { get; set; } = true;
        public bool AllowsPickup { get; set; } = true;
        public List<ClientBranchDto> Branches { get; set; } = new();
    }
}
