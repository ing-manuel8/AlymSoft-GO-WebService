using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AlymSoftGo.Application.Interfaces;
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

        [HttpGet("company/{idEmpresa:int}")]
        public async Task<IActionResult> GetProducts(int idEmpresa, [FromQuery] int? idCategoria = null, [FromQuery] int? idSucursal = null)
        {
            var response = await _productService.GetProductsAsync<JArray>(idEmpresa, idCategoria, idSucursal);
            return HandleResponse(response);
        }

        [HttpGet("{idProducto:int}")]
        public async Task<IActionResult> GetProductById(int idProducto, [FromQuery] int? idSucursal = null)
        {
            var response = await _productService.GetProductByIdAsync<JObject>(idProducto, idSucursal);
            return HandleResponse(response);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SaveProduct([FromBody] object productParams)
        {
            var response = await _productService.SaveProductAsync(productParams);
            return HandleResponse(response);
        }

        [HttpDelete("{idProducto:int}/company/{idEmpresa:int}")]
        [Authorize]
        public async Task<IActionResult> DeleteProduct(int idProducto, int idEmpresa)
        {
            var response = await _productService.DeleteProductAsync(idProducto, idEmpresa, CurrentUserIdentifier);
            return HandleResponse(response);
        }
    }
}
