using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AlymSoftGo.Domain.Params.Order
{
    /// <summary>
    /// Parámetros para listar pedidos por empresa con filtros opcionales
    /// </summary>
    public class GetOrdersByCompanyParams
    {
        [JsonProperty("@idEmpresa")]
        [Required]
        public int CompanyId { get; set; }

        [JsonProperty("@idSucursal")]
        public int? BranchId { get; set; }

        [JsonProperty("@idCatEstadoPedido")]
        public int? StatusId { get; set; }
    }
}
