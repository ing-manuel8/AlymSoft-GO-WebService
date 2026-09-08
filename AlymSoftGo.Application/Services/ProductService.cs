using AlymSoftGo.Application.Interfaces;
using AlymSoftGo.Domain.Common;
using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.Interfaces.Repositories;
using AlymSoftGo.Domain.Interfaces.Services;
using AlymSoftGo.Domain.Params.Product;

namespace AlymSoftGo.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IUserContextService _userContext;

        public ProductService(IProductRepository productRepository, IUserContextService userContext)
        {
            _productRepository = productRepository;
            _userContext = userContext;
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

        public async Task<RepositoryResponse<EmptyDto>> SaveProductAsync(SaveProductRequestDto request, string? currentUser = null)
        {
            // Empresa y usuario directamente desde contexto
            var companyId = _userContext.GetCompanyId();
            var branchId = request.BranchId;
            var user = _userContext.GetUserIdentifier();

            var @params = new SaveProductParams
            {
                ProductId = request.ProductId,
                CompanyId = companyId,
                BranchId = branchId,
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
                @params.User = _userContext.GetUserName();
            }

            var result = await _productRepository.SaveProductAsync(@params);
            return RepositoryResponse<EmptyDto>.FromSuccess(result);
        }

        public async Task<RepositoryResponse<EmptyDto>> DeleteProductAsync(int productId, int companyId = 0, string? currentUser = null)
        {
            // Empresa y usuario directamente desde contexto
            var effectiveCompanyId = _userContext.GetCompanyId();
            var effectiveUser = _userContext.GetUserName();

            var @params = new DeleteProductParams
            {
                ProductId = productId,
                CompanyId = effectiveCompanyId,
                UpdatedUser = effectiveUser
            };

            return await DeleteProductAsync(@params);
        }

        public async Task<RepositoryResponse<EmptyDto>> DeleteProductAsync(DeleteProductParams @params)
        {
            if (string.IsNullOrWhiteSpace(@params.UpdatedUser))
            {
                @params.UpdatedUser = _userContext.GetUserName();
            }

            var result = await _productRepository.DeleteProductAsync(@params);
            return RepositoryResponse<EmptyDto>.FromSuccess(result);
        }
    }
}

