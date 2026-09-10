using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AlymSoftGo.Application.Interfaces;
using AlymSoftGo.Domain.DTOs.Client;

namespace AlymSoftGo.API.Controllers
{
    [Route("api/store")]
    public class ClientStoreController : BaseController
    {
        private readonly IClientStoreService _clientStoreService;

        public ClientStoreController(IClientStoreService clientStoreService)
        {
            _clientStoreService = clientStoreService;
        }

        [HttpGet("{slug}")]
        public async Task<IActionResult> GetStoreInfo(string slug, [FromQuery] int? branchId = null)
        {
            var response = await _clientStoreService.GetStoreBySlugAsync(slug, branchId);
            return HandleResponse(response);
        }

        [HttpGet("{slug}/catalog")]
        public async Task<IActionResult> GetCatalog(
            string slug,
            [FromQuery] int? branchId = null,
            [FromQuery] int? categoryId = null,
            [FromQuery] string? search = null)
        {
            var response = await _clientStoreService.GetCatalogAsync(slug, branchId, categoryId, search);
            return HandleResponse(response);
        }

        [HttpGet("{slug}/products/{productId:int}")]
        public async Task<IActionResult> GetProductDetail(
            string slug,
            int productId,
            [FromQuery] int? branchId = null)
        {
            var response = await _clientStoreService.GetProductDetailAsync(productId, branchId);
            return HandleResponse(response);
        }

        [HttpPost("{slug}/orders")]
        public async Task<IActionResult> CreateOrder(string slug, [FromBody] ClientCreateOrderRequestDto request)
        {
            request.StoreSlug = slug;
            var response = await _clientStoreService.CreateOrderAsync(request);
            return HandleResponse(response);
        }

        [HttpGet("{slug}/orders/{folio}")]
        public async Task<IActionResult> GetOrderStatus(string slug, string folio, [FromQuery] string? phone = null)
        {
            var response = await _clientStoreService.GetOrderStatusAsync(folio, phone);
            return HandleResponse(response);
        }
    }
}
