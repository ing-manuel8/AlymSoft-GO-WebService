namespace AlymSoftGo.Domain.DTOs.Client
{
    public class ClientCategoryDto
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
