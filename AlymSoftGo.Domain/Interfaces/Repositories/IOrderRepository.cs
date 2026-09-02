using AlymSoftGo.Domain.DTOs;

namespace AlymSoftGo.Domain.Interfaces.Repositories
{
    public interface IOrderRepository
    {
        Task<TData> GetOrdersByCompanyAsync<TData>(int idEmpresa, int? idSucursal = null, int? idCatEstadoPedido = null) where TData : class, new();
        Task<TData> GetOrderByIdAsync<TData>(int idPedido) where TData : class, new();
        Task<TData> CreateOrderAsync<TData>(object @params) where TData : class, new();
        Task<EmptyDto> UpdateOrderStatusAsync(object @params);
    }
}
