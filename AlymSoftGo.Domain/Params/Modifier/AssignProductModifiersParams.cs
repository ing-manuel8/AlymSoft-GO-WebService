using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AlymSoftGo.Domain.Params.Modifier
{
    public class AssignProductModifiersParams
    {
        [JsonProperty("@idProducto")]
        [Required]
        public int ProductId { get; set; }

        [JsonProperty("@idEmpresa")]
        [Required]
        public int CompanyId { get; set; }

        [JsonProperty("@vGruposJson")]
        [Required]
        public string GroupsJson { get; set; } = string.Empty;

        [JsonProperty("@vUser")]
        [Required]
        public string User { get; set; } = string.Empty;
    }
}
