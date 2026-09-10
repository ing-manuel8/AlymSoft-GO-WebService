using System.Collections.Generic;

namespace AlymSoftGo.Domain.DTOs.Client
{
    public class ClientProductDetailDto : ClientProductDto
    {
        public List<ClientModifierGroupDto> ModifierGroups { get; set; } = new();
    }
}
