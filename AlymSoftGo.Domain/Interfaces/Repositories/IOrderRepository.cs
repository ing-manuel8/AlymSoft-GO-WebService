using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.Params.Order;

namespace AlymSoftGo.Domain.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<TData> GetOrdersByCompanyAsync<TData>(GetOrdersByCompanyParams @params) where TData : class, new();
        Task<TData> GetOrderByIdAsync<TData>(GetOrderByIdParams @params) where TData : class, new();
        Task<TData> CreateOrderAsync<TData>(CreateOrderParams @params) where TData : class, new();
        Task<EmptyDto> UpdateOrderStatusAsync(UpdateOrderStatusParams @params);
    }
}
