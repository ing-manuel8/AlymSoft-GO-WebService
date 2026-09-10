using System.Collections.Generic;

namespace AlymSoftGo.Domain.DTOs.Modifier
{
    public class ModifierGroupsContainerDto
    {
        public List<ModifierGroupDto> Groups { get; set; } = new();
        public List<ModifierDto> Modifiers { get; set; } = new();
    }
}
