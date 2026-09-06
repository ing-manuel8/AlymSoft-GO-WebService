using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.Interfaces.Persistence;
using AlymSoftGo.Domain.Interfaces.Repositories;
using AlymSoftGo.Domain.Params.Product;
using AlymSoftGo.Infrastructure.Repositories.Base;

namespace AlymSoftGo.Infrastructure.Repositories
{
    public class ProductRepository : GenericRepository, IProductRepository
    {
        public ProductRepository(IDataAccess dataAccess) : base(dataAccess)
        {
        }

        public async Task<TData> GetProductsByCompanyAsync<TData>(GetProductsParams @params) where TData : class, new()
        {
            return await ResolveSpAsync<TData>(@params);
        }

        public async Task<TData> GetProductByIdAsync<TData>(GetProductByIdParams @params) where TData : class, new()
        {
            return await ResolveSpAsync<TData>(@params);
        }

        public async Task<EmptyDto> SaveProductAsync(SaveProductParams @params)
        {
            return await ResolveSpAsync<EmptyDto>(@params);
        }

        public async Task<EmptyDto> DeleteProductAsync(DeleteProductParams @params)
        {
            return await ResolveSpAsync<EmptyDto>(@params);
        }
    }
}
