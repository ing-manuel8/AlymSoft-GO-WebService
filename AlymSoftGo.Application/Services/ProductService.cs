using AlymSoftGo.Application.Interfaces;
using AlymSoftGo.Domain.Common;
using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.Interfaces.Repositories;
using AlymSoftGo.Domain.Params.Product;

namespace AlymSoftGo.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<RepositoryResponse<TData>> GetProductsAsync<TData>(GetProductsParams @params) where TData : class, new()
        {
            var data = await _productRepository.GetProductsByCompanyAsync<TData>(@params);
            return RepositoryResponse<TData>.FromSuccess(data);
        }

        public async Task<RepositoryResponse<TData>> GetProductByIdAsync<TData>(GetProductByIdParams @params) where TData : class, new()
        {
            var data = await _productRepository.GetProductByIdAsync<TData>(@params);
            return RepositoryResponse<TData>.FromSuccess(data);
        }

        public async Task<RepositoryResponse<EmptyDto>> SaveProductAsync(SaveProductParams @params)
        {
            var result = await _productRepository.SaveProductAsync(@params);
            return RepositoryResponse<EmptyDto>.FromSuccess(result);
        }

        public async Task<RepositoryResponse<EmptyDto>> DeleteProductAsync(DeleteProductParams @params)
        {
            var result = await _productRepository.DeleteProductAsync(@params);
            return RepositoryResponse<EmptyDto>.FromSuccess(result);
        }
    }
}
