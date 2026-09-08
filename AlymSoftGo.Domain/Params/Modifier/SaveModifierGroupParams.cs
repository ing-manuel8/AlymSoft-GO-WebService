using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace AlymSoftGo.Domain.Params.Modifier
{
    public class SaveModifierGroupParams
    {
        [JsonProperty("@idGrupoModificador")]
        public int? Id { get; set; }

        [JsonProperty("@idEmpresa")]
        [Required]
        public int CompanyId { get; set; }

        [JsonProperty("@vNombre")]
        [Required]
        [StringLength(150)]
        public string Name { get; set; } = string.Empty;

        [JsonProperty("@vDescripcion")]
        [StringLength(255)]
        public string? Description { get; set; }

        [JsonProperty("@bEsObligatorio")]
        public bool IsRequired { get; set; }

        [JsonProperty("@nMinimoSeleccion")]
        public int MinSelect { get; set; }

        [JsonProperty("@nMaximoSeleccion")]
        public int MaxSelect { get; set; }

        [JsonProperty("@bPermiteParticion")]
        public bool AllowsPartition { get; set; }

        [JsonProperty("@vOpcionesJson")]
        public string? OptionsJson { get; set; }

        [JsonProperty("@idProducto")]
        public int? ProductId { get; set; }

        [JsonProperty("@vUser")]
        [Required]
        public string User { get; set; } = string.Empty;
    }
}
