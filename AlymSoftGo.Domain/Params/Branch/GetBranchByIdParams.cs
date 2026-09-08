using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AlymSoftGo.Domain.Params.Branch
{
    /// <summary>
    /// Parámetros para obtener detalle de una sucursal por ID y Empresa
    /// </summary>
    public class GetBranchByIdParams
    {
        [JsonProperty("@idSucursal")]
        [Required]
        public int BranchId { get; set; }

        [JsonProperty("@idEmpresa")]
        [Required]
        public int CompanyId { get; set; }
    }
}
