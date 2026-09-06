using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AlymSoftGo.Domain.Params.Product
{
    /// <summary>
    /// Parámetros para dar de baja lógica a un producto
    /// </summary>
    public class DeleteProductParams
    {
        [JsonProperty("@idProducto")]
        [Required]
        public int ProductId { get; set; }

        [JsonProperty("@idEmpresa")]
        [Required]
        public int CompanyId { get; set; }

        [JsonProperty("@vUpdatedUser")]
        public string? UpdatedUser { get; set; } = "SYSTEM";
    }
}
