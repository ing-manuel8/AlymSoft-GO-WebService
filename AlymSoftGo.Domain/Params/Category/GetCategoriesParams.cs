using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AlymSoftGo.Domain.Params.Category
{
    /// <summary>
    /// Parámetros para listar categorías por empresa
    /// </summary>
    public class GetCategoriesParams
    {
        [JsonProperty("@idEmpresa")]
        [Required]
        public int CompanyId { get; set; }
    }
}
