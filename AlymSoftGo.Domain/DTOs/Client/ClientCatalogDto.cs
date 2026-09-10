using System.Collections.Generic;

namespace AlymSoftGo.Domain.DTOs.Client
{
    public class ClientCatalogDto
    {
        public ClientStoreInfoDto Store { get; set; } = new();
        public List<ClientCategoryDto> Categories { get; set; } = new();
        public List<ClientProductDto> Products { get; set; } = new();
    }
}
