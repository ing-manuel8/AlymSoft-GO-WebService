using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AlymSoftGo.Domain.Params.Modifier
{
    public class GetModifierGroupsByCompanyParams
    {
        [JsonProperty("@idEmpresa")]
        [Required]
        public int CompanyId { get; set; }
    }
}
