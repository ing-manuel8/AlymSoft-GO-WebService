using AlymSoftGo.Application.Interfaces;
using AlymSoftGo.Domain.Common;
using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.Interfaces.Repositories;

namespace AlymSoftGo.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<RepositoryResponse<TData>> GetProductsAsync<TData>(int idEmpresa, int? idCategoria = null, int? idSucursal = null) where TData : class, new()
        {
            var data = await _productRepository.GetProductsByCompanyAsync<TData>(idEmpresa, idCategoria, idSucursal);
            return RepositoryResponse<TData>.FromSuccess(data);
        }

        public async Task<RepositoryResponse<TData>> GetProductByIdAsync<TData>(int idProducto, int? idSucursal = null) where TData : class, new()
        {
            var data = await _productRepository.GetProductByIdAsync<TData>(idProducto, idSucursal);
            return RepositoryResponse<TData>.FromSuccess(data);
        }

        public async Task<RepositoryResponse<EmptyDto>> SaveProductAsync(object @params)
        {
            var result = await _productRepository.SaveProductAsync(@params);
            return RepositoryResponse<EmptyDto>.FromSuccess(result, "Product saved successfully.");
        }

        public async Task<RepositoryResponse<EmptyDto>> DeleteProductAsync(int idProducto, int idEmpresa, string vUpdatedUser)
        {
            var result = await _productRepository.DeleteProductAsync(idProducto, idEmpresa, vUpdatedUser);
            return RepositoryResponse<EmptyDto>.FromSuccess(result, "Product deleted successfully.");
        }
    }
}
