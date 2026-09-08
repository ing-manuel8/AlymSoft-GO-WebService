using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AlymSoftGo.Application.Interfaces;
using AlymSoftGo.Domain.DTOs;

namespace AlymSoftGo.API.Controllers
{
    public class OrdersController : BaseController
    {
        private readonly IOrderService _orderService;

        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet]
        [HttpGet("company/{companyId:int}")]
        [Authorize]
        public async Task<IActionResult> GetOrders([FromRoute] int? companyId = null, [FromQuery] int? branchId = null, [FromQuery] int? statusId = null)
        {
            var response = await _orderService.GetOrdersByCompanyAsync(branchId, statusId);
            return HandleResponse(response);
        }

        [HttpGet("{orderId:int}")]
        [Authorize]
        public async Task<IActionResult> GetOrderById(int orderId)
        {
            var response = await _orderService.GetOrderByIdAsync(orderId);
            return HandleResponse(response);
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderRequestDto request)
        {
            var response = await _orderService.CreateOrderAsync(request);
            return HandleResponse(response);
        }

        [HttpPut("{orderId:int}/status")]
        [Authorize]
        public async Task<IActionResult> UpdateOrderStatus(int orderId, [FromBody] UpdateOrderStatusRequestDto request)
        {
            var response = await _orderService.UpdateOrderStatusAsync(orderId, request);
            return HandleResponse(response);
        }
    }
}

