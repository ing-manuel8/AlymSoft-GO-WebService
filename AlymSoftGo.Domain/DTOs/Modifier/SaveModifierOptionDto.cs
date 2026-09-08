using System.ComponentModel.DataAnnotations;

namespace AlymSoftGo.Domain.DTOs.Modifier
{
    public class SaveModifierOptionDto
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; } = string.Empty;

        [Range(0, 100000)]
        public decimal ExtraPrice { get; set; }
    }
}
