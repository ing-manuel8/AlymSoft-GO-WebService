namespace AlymSoftGo.Domain.DTOs
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }

    public class SaveCategoryRequestDto
    {
        public int? CategoryId { get; set; }
        public int? IdCategoria { set => CategoryId = value; }

        public int CompanyId { get; set; }
        public int IdEmpresa { set => CompanyId = value; }

        public string Name { get; set; } = string.Empty;
        public string VNombre { set => Name = value; }

        public string? Description { get; set; }
        public string? VDescripcion { set => Description = value; }

        public string? User { get; set; } = "SYSTEM";
        public string? VUser { set => User = value; }
    }
}
