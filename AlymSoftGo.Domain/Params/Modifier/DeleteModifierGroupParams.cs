using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AlymSoftGo.Domain.Params.Modifier
{
    public class DeleteModifierGroupParams
    {
        [JsonProperty("@idGrupoModificador")]
        [Required]
        public int Id { get; set; }

        [JsonProperty("@idEmpresa")]
        [Required]
        public int CompanyId { get; set; }

        [JsonProperty("@vUser")]
        [Required]
        public string User { get; set; } = string.Empty;
    }
}
