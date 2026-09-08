using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.Interfaces.Persistence;
using AlymSoftGo.Domain.Interfaces.Repositories;
using AlymSoftGo.Domain.Params.Order;
using AlymSoftGo.Infrastructure.Repositories.Base;

namespace AlymSoftGo.Infrastructure.Repositories
{
    public class OrderRepository : GenericRepository, IOrderRepository
    {
        public OrderRepository(IDataAccess dataAccess) : base(dataAccess)
        {
        }

        public async Task<TData> GetOrdersByCompanyAsync<TData>(GetOrdersByCompanyParams @params) where TData : class, new()
        {
            return await ResolveSpAsync<TData>(@params);
        }

        public async Task<TData> GetOrderByIdAsync<TData>(GetOrderByIdParams @params) where TData : class, new()
        {
            return await ResolveSpAsync<TData>(@params);
        }

        public async Task<TData> CreateOrderAsync<TData>(CreateOrderParams @params) where TData : class, new()
        {
            return await ResolveSpAsync<TData>(@params);
        }

        public async Task<EmptyDto> UpdateOrderStatusAsync(UpdateOrderStatusParams @params)
        {
            return await ResolveSpAsync<EmptyDto>(@params);
        }
    }
}
