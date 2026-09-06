using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AlymSoftGo.Domain.Params.Product
{
    /// <summary>
    /// Parámetros para obtener detalle de un producto por ID
    /// </summary>
    public class GetProductByIdParams
    {
        [JsonProperty("@idProducto")]
        [Required]
        public int ProductId { get; set; }

        [JsonProperty("@idSucursal")]
        public int? BranchId { get; set; }
    }
}
