using System;

namespace AlymSoftGo.Domain.DTOs.Client
{
    public class ClientOrderStatusDto
    {
        public int Id { get; set; }
        public string Folio { get; set; } = string.Empty;
        public int CompanyId { get; set; }
        public int? BranchId { get; set; }
        public string BranchName { get; set; } = string.Empty;
        public string CustomerName { get; set; } = string.Empty;
        public string CustomerPhone { get; set; } = string.Empty;
        public int FulfillmentType { get; set; }
        public string FulfillmentTypeName { get; set; } = string.Empty;
        public string? DeliveryAddress { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; } = string.Empty;
        public string? StatusDescription { get; set; }
        public decimal Total { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
