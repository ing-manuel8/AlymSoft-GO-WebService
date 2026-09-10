using System.Collections.Generic;
using System.Threading.Tasks;
using AlymSoftGo.Domain.DTOs.Client;
using AlymSoftGo.Domain.Params.Client;

namespace AlymSoftGo.Domain.Interfaces.Repositories
{
    public interface IClientStoreRepository
    {
        Task<ClientStoreInfoDto> GetStoreBySlugAsync(GetStoreBySlugParams @params);
        Task<ClientCatalogContentDto> GetCatalogAsync(GetCatalogParams @params);
        Task<ClientProductDetailDto> GetProductDetailAsync(GetProductDetailParams @params);
        Task<ClientOrderResultDto> CreateOrderAsync(CreateOrderParams @params);
        Task<ClientOrderStatusDto> GetOrderStatusAsync(GetOrderStatusParams @params);
    }
}
