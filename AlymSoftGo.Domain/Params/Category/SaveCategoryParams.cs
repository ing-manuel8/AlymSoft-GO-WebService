using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AlymSoftGo.Domain.Params.Category
{
    /// <summary>
    /// Parámetros para crear o actualizar una categoría
    /// </summary>
    public class SaveCategoryParams
    {
        [JsonProperty("@idCategoria")]
        public int? CategoryId { get; set; }

        [JsonProperty("@idEmpresa")]
        [Required]
        public int CompanyId { get; set; }

        [JsonProperty("@vNombre")]
        [Required]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("@vDescripcion")]
        public string? Description { get; set; }

        [JsonProperty("@vUser")]
        public string? User { get; set; } = "SYSTEM";
    }
}
