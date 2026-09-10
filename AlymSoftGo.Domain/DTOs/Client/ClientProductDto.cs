namespace AlymSoftGo.Domain.DTOs.Client
{
    public class ClientProductDto
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; } = string.Empty;
        public int ProductTypeId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string? ImagesJson { get; set; }
        public decimal Price { get; set; }
        public decimal? OfferPrice { get; set; }
        public bool IsOnSale { get; set; }
        public string? SaleTag { get; set; }
        public bool TrackStock { get; set; }
        public decimal Stock { get; set; }
        public bool IsAvailable { get; set; } = true;
    }
}
