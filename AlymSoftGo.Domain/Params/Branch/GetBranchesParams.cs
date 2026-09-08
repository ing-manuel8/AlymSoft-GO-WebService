using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AlymSoftGo.Domain.Params.Branch
{
    /// <summary>
    /// Parámetros para listar sucursales activas de una empresa
    /// </summary>
    public class GetBranchesParams
    {
        [JsonProperty("@idEmpresa")]
        [Required]
        public int CompanyId { get; set; }
    }
}
