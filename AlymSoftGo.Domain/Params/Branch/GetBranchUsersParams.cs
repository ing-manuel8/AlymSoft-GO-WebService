using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AlymSoftGo.Domain.Params.Branch
{
    public class GetBranchUsersParams
    {
        [JsonProperty("@idEmpresa")]
        [Required]
        public int CompanyId { get; set; }
    }
}
