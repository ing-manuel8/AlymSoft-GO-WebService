using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AlymSoftGo.Domain.Params.Category
{
    /// <summary>
    /// Parámetros para dar de baja lógica a una categoría
    /// </summary>
    public class DeleteCategoryParams
    {
        [JsonProperty("@idCategoria")]
        [Required]
        public int CategoryId { get; set; }

        [JsonProperty("@idEmpresa")]
        [Required]
        public int CompanyId { get; set; }

        [JsonProperty("@vUpdatedUser")]
        public string? UpdatedUser { get; set; } = "SYSTEM";
    }
}
