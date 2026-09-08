using AlymSoftGo.Domain.Common;
using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.Params.Product;

namespace AlymSoftGo.Application.Interfaces
{
    public interface IProductService
    {
        Task<RepositoryResponse<TData>> GetProductsAsync<TData>(GetProductsParams @params) where TData : class, new();
        Task<RepositoryResponse<TData>> GetProductByIdAsync<TData>(GetProductByIdParams @params) where TData : class, new();
        Task<RepositoryResponse<EmptyDto>> SaveProductAsync(SaveProductRequestDto request, string? currentUser = null);
        Task<RepositoryResponse<EmptyDto>> SaveProductAsync(SaveProductParams @params);
        Task<RepositoryResponse<EmptyDto>> DeleteProductAsync(int productId, int companyId, string? currentUser = null);
        Task<RepositoryResponse<EmptyDto>> DeleteProductAsync(DeleteProductParams @params);
    }
}
