using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AlymSoftGo.Domain.Params.Product
{
    /// <summary>
    /// Parámetros para listar productos por empresa y filtros
    /// </summary>
    public class GetProductsParams
    {
        [JsonProperty("@idEmpresa")]
        [Required]
        public int CompanyId { get; set; }

        [JsonProperty("@idSucursal")]
        public int? BranchId { get; set; }

        [JsonProperty("@idCategoria")]
        public int? CategoryId { get; set; }

        [JsonProperty("@vSearch")]
        public string? SearchText { get; set; }
    }
}
