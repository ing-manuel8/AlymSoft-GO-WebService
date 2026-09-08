using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AlymSoftGo.Domain.Params.Modifier
{
    public class GetModifierGroupsByProductParams
    {
        [JsonProperty("@idProducto")]
        [Required]
        public int ProductId { get; set; }

        [JsonProperty("@idEmpresa")]
        [Required]
        public int CompanyId { get; set; }
    }
}
