using System.ComponentModel.DataAnnotations;

namespace AlymSoftGo.Domain.DTOs.Category
{
    public class SaveCategoryRequestDto
    {
        public int? CategoryId { get; set; }
        public int? IdCategoria { set => CategoryId = value; }

        public int? CompanyId { get; set; }
        public int? IdEmpresa { set => CompanyId = value; }

        [Required(ErrorMessage = "NAME_REQUIRED")]
        public string Name { get; set; } = string.Empty;
        public string VNombre { set => Name = value; }

        public string? Description { get; set; }
        public string? VDescripcion { set => Description = value; }

        public string? User { get; set; }
        public string? VUser { set => User = value; }
    }
}
