using Newtonsoft.Json;
using AlymSoftGo.Application.Interfaces;
using AlymSoftGo.Domain.Common;
using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.Interfaces.Repositories;
using AlymSoftGo.Domain.Interfaces.Services;
using AlymSoftGo.Domain.Params.Order;

namespace AlymSoftGo.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IUserContextService _userContext;

        public OrderService(IOrderRepository orderRepository, IUserContextService userContext)
        {
            _orderRepository = orderRepository;
            _userContext = userContext;
        }

        public async Task<RepositoryResponse<List<OrderListDto>>> GetOrdersByCompanyAsync(int? branchId = null, int? statusId = null)
        {
            var @params = new GetOrdersByCompanyParams
            {
                CompanyId = _userContext.GetCompanyId(),
                BranchId = branchId,
                StatusId = statusId
            };

            var data = await _orderRepository.GetOrdersByCompanyAsync<List<OrderListDto>>(@params);
            return RepositoryResponse<List<OrderListDto>>.FromSuccess(data);
        }

        public async Task<RepositoryResponse<OrderDetailDto>> GetOrderByIdAsync(int orderId)
        {
            var @params = new GetOrderByIdParams
            {
                OrderId = orderId
            };

            var data = await _orderRepository.GetOrderByIdAsync<OrderDetailDto>(@params);
            return RepositoryResponse<OrderDetailDto>.FromSuccess(data);
        }

        public async Task<RepositoryResponse<CreatedOrderResultDto>> CreateOrderAsync(CreateOrderRequestDto request)
        {
            var @params = new CreateOrderParams
            {
                CompanyId = _userContext.GetCompanyId(),
                BranchId = request.BranchId,
                CustomerId = request.CustomerId,
                CustomerName = request.CustomerName,
                CustomerPhone = request.CustomerPhone,
                CustomerEmail = request.CustomerEmail,
                DeliveryTypeId = request.DeliveryTypeId,
                BranchName = request.BranchName,
                DeliveryAddress = request.DeliveryAddress,
                OrderNotes = request.OrderNotes,
                PaymentMethodId = request.PaymentMethodId,
                Subtotal = request.Subtotal,
                ShippingCost = request.ShippingCost,
                Discount = request.Discount,
                Total = request.Total,
                IsPaid = request.IsPaid,
                ItemsJson = request.Items != null && request.Items.Count > 0
                    ? JsonConvert.SerializeObject(request.Items)
                    : "[]",
                User = _userContext.GetUserIdentifier()
            };

            var result = await _orderRepository.CreateOrderAsync<CreatedOrderResultDto>(@params);
            return RepositoryResponse<CreatedOrderResultDto>.FromSuccess(result);
        }

        public async Task<RepositoryResponse<UpdatedOrderStatusResultDto>> UpdateOrderStatusAsync(int orderId, UpdateOrderStatusRequestDto request)
        {
            var @params = new UpdateOrderStatusParams
            {
                OrderId = orderId,
                NewStatusId = request.StatusId,
                Reason = request.Reason,
                User = _userContext.GetUserIdentifier()
            };

            await _orderRepository.UpdateOrderStatusAsync(@params);
            var result = new UpdatedOrderStatusResultDto { Id = orderId, StatusId = request.StatusId };
            return RepositoryResponse<UpdatedOrderStatusResultDto>.FromSuccess(result);
        }
    }
}
