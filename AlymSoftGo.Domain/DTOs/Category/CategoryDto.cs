using Newtonsoft.Json;

namespace AlymSoftGo.Domain.DTOs.Category
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public int IdCategoria { set => Id = value; }

        public string Name { get; set; } = string.Empty;
        public string VNombre { set => Name = value; }

        [JsonProperty(NullValueHandling = NullValueHandling.Include)]
        public string? Description { get; set; }
        public string? VDescripcion { set => Description = value; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public int? CompanyId { get; set; }
        public int? IdEmpresa { set => CompanyId = value; }

        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public bool? IsActive { get; set; }
        public bool? BIsActive { set => IsActive = value; }
    }
}
