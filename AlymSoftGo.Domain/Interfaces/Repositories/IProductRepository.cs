using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.Params.Product;

namespace AlymSoftGo.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<TData> GetProductsByCompanyAsync<TData>(GetProductsParams @params) where TData : class, new();
        Task<TData> GetProductByIdAsync<TData>(GetProductByIdParams @params) where TData : class, new();
        Task<EmptyDto> SaveProductAsync(SaveProductParams @params);
        Task<EmptyDto> DeleteProductAsync(DeleteProductParams @params);
    }
}
