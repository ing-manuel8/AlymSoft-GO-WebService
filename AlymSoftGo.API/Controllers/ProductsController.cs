using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AlymSoftGo.Application.Interfaces;
using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.Params.Product;
using Newtonsoft.Json.Linq;

namespace AlymSoftGo.API.Controllers
{
    public class ProductsController : BaseController
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("company/{companyId:int}")]
        public async Task<IActionResult> GetProducts(
            int companyId,
            [FromQuery] int? categoryId = null,
            [FromQuery] int? idCategoria = null,
            [FromQuery] int? branchId = null,
            [FromQuery] int? idSucursal = null,
            [FromQuery] string? search = null)
        {
            var @params = new GetProductsParams
            {
                CompanyId = companyId,
                CategoryId = categoryId ?? idCategoria,
                BranchId = branchId ?? idSucursal,
                SearchText = search
            };
            var response = await _productService.GetProductsAsync<JArray>(@params);
            return HandleResponse(response);
        }

        [HttpGet("{productId:int}")]
        public async Task<IActionResult> GetProductById(
            int productId,
            [FromQuery] int? branchId = null,
            [FromQuery] int? idSucursal = null)
        {
            var @params = new GetProductByIdParams
            {
                ProductId = productId,
                BranchId = branchId ?? idSucursal
            };
            var response = await _productService.GetProductByIdAsync<JObject>(@params);
            return HandleResponse(response);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SaveProduct([FromBody] SaveProductRequestDto request)
        {
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
                User = !string.IsNullOrEmpty(request.User) && request.User != "SYSTEM" ? request.User : CurrentUserIdentifier
            };
            var response = await _productService.SaveProductAsync(@params);
            return HandleResponse(response);
        }

        [HttpDelete("{productId:int}/company/{companyId:int}")]
        [Authorize]
        public async Task<IActionResult> DeleteProduct(int productId, int companyId)
        {
            var @params = new DeleteProductParams
            {
                ProductId = productId,
                CompanyId = companyId,
                UpdatedUser = CurrentUserIdentifier
            };
            var response = await _productService.DeleteProductAsync(@params);
            return HandleResponse(response);
        }
    }
}
