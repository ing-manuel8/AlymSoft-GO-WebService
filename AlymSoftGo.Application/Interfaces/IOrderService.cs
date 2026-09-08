using AlymSoftGo.Domain.Common;
using AlymSoftGo.Domain.DTOs;

namespace AlymSoftGo.Application.Interfaces
{
    public interface IOrderService
    {
        Task<RepositoryResponse<List<OrderListDto>>> GetOrdersByCompanyAsync(int? branchId = null, int? statusId = null);
        Task<RepositoryResponse<OrderDetailDto>> GetOrderByIdAsync(int orderId);
        Task<RepositoryResponse<CreatedOrderResultDto>> CreateOrderAsync(CreateOrderRequestDto request);
        Task<RepositoryResponse<UpdatedOrderStatusResultDto>> UpdateOrderStatusAsync(int orderId, UpdateOrderStatusRequestDto request);
    }
}
