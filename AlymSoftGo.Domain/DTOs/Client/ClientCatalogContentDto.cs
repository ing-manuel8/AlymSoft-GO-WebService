using System.Collections.Generic;

namespace AlymSoftGo.Domain.DTOs.Client
{
    public class ClientCatalogContentDto
    {
        public List<ClientCategoryDto> Categories { get; set; } = new();
        public List<ClientProductDto> Products { get; set; } = new();
    }
}
