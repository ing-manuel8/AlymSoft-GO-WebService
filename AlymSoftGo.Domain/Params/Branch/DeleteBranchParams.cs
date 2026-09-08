using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AlymSoftGo.Domain.Params.Branch
{
    /// <summary>
    /// Parámetros para dar de baja lógica una sucursal
    /// </summary>
    public class DeleteBranchParams
    {
        [JsonProperty("@idSucursal")]
        [Required]
        public int BranchId { get; set; }

        [JsonProperty("@idEmpresa")]
        [Required]
        public int CompanyId { get; set; }

        [JsonProperty("@vUser")]
        [Required]
        public string User { get; set; } = "SYSTEM";
    }
}
