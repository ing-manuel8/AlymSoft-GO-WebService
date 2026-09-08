using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlymSoftGo.Domain.DTOs.Modifier
{
    public class AssignProductModifiersRequestDto
    {
        [Required]
        public int ProductId { get; set; }

        public List<ProductModifierAssignmentDto> Groups { get; set; } = new();
    }
}
