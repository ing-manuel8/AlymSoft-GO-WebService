using System;

namespace AlymSoftGo.Domain.DTOs.Client
{
    public class ClientOrderResultDto
    {
        public int Id { get; set; }
        public string Folio { get; set; } = string.Empty;
        public int CompanyId { get; set; }
        public int? BranchId { get; set; }
        public string? BranchName { get; set; }
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
        public decimal Total { get; set; }
        public int FulfillmentType { get; set; }
        public DateTime OrderDate { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; } = string.Empty;
    }
}
