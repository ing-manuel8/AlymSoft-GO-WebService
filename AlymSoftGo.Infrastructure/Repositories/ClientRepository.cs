using System.Collections.Generic;
using System.Threading.Tasks;
using AlymSoftGo.Domain.DTOs.Client;
using AlymSoftGo.Domain.Interfaces.Persistence;
using AlymSoftGo.Domain.Interfaces.Repositories;
using AlymSoftGo.Domain.Params.Client;
using AlymSoftGo.Infrastructure.Repositories.Base;

namespace AlymSoftGo.Infrastructure.Repositories
{
    public class ClientRepository : GenericRepository, IClientStoreRepository
    {
        public ClientRepository(IDataAccess dataAccess) : base(dataAccess)
        {
        }

        public async Task<ClientStoreInfoDto> GetStoreBySlugAsync(GetStoreBySlugParams @params)
        {
            return await ResolveSpAsync<ClientStoreInfoDto>(@params);
        }

        public async Task<ClientCatalogContentDto> GetCatalogAsync(GetCatalogParams @params)
        {
            return await ResolveSpAsync<ClientCatalogContentDto>(@params);
        }

        public async Task<ClientProductDetailDto> GetProductDetailAsync(GetProductDetailParams @params)
        {
            return await ResolveSpAsync<ClientProductDetailDto>(@params);
        }

        public async Task<ClientOrderResultDto> CreateOrderAsync(CreateOrderParams @params)
        {
            return await ResolveSpAsync<ClientOrderResultDto>(@params);
        }

        public async Task<ClientOrderStatusDto> GetOrderStatusAsync(GetOrderStatusParams @params)
        {
            return await ResolveSpAsync<ClientOrderStatusDto>(@params);
        }
    }
}
