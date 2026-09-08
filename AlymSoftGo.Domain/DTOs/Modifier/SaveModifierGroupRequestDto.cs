using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlymSoftGo.Domain.DTOs.Modifier
{
    public class SaveModifierGroupRequestDto
    {
        public int? Id { get; set; }
        public int? ProductId { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; } = string.Empty;

        [StringLength(255)]
        public string? Description { get; set; }

        public bool IsRequired { get; set; }

        [Range(0, 100)]
        public int MinSelect { get; set; } = 0;

        [Range(1, 100)]
        public int MaxSelect { get; set; } = 1;

        public bool AllowsPartition { get; set; }

        public List<SaveModifierOptionDto> Options { get; set; } = new();
    }
}
