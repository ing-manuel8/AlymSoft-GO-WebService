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

        public async Task<RepositoryResponse<EmptyDto>> SaveProductAsync(SaveProductRequestDto request, string currentUser)
        {
            var user = !string.IsNullOrWhiteSpace(currentUser)
                ? currentUser
                : (!string.IsNullOrWhiteSpace(request.User) ? request.User : "SYSTEM");

            var @params = new SaveProductParams
            {
                ProductId = request.ProductId,
                CompanyId = request.CompanyId,
                BranchId = request.BranchId,
                CategoryId = request.CategoryId,
                ProductTypeId = request.ProductTypeId,
                UnitTypeId = request.UnitTypeId,
                Sku = request.Sku,
                Barcode = request.Barcode,
                Name = request.Name,
                Description = request.Description,
                ImagesJson = request.ImagesJson,
                Cost = request.Cost,
                Price = request.Price,
                OfferPrice = request.OfferPrice,
                TrackStock = request.TrackStock,
                Stock = request.Stock,
                MinStock = request.MinStock,
                IsOnSale = request.IsOnSale,
                SaleTag = request.SaleTag,
                User = user
            };

            return await SaveProductAsync(@params);
        }

        public async Task<RepositoryResponse<EmptyDto>> SaveProductAsync(SaveProductParams @params)
        {
            if (string.IsNullOrWhiteSpace(@params.User))
            {
                @params.User = "SYSTEM";
            }

            var result = await _productRepository.SaveProductAsync(@params);
            return RepositoryResponse<EmptyDto>.FromSuccess(result);
        }

        public async Task<RepositoryResponse<EmptyDto>> DeleteProductAsync(int productId, int companyId, string currentUser)
        {
            var @params = new DeleteProductParams
            {
                ProductId = productId,
                CompanyId = companyId,
                UpdatedUser = !string.IsNullOrWhiteSpace(currentUser) ? currentUser : "SYSTEM"
            };

            return await DeleteProductAsync(@params);
        }

        public async Task<RepositoryResponse<EmptyDto>> DeleteProductAsync(DeleteProductParams @params)
        {
            if (string.IsNullOrWhiteSpace(@params.UpdatedUser))
            {
                @params.UpdatedUser = "SYSTEM";
            }

            var result = await _productRepository.DeleteProductAsync(@params);
            return RepositoryResponse<EmptyDto>.FromSuccess(result);
        }
    }
}
