using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.Interfaces.Persistence;
using AlymSoftGo.Domain.Interfaces.Repositories;
using AlymSoftGo.Infrastructure.Repositories.Base;

namespace AlymSoftGo.Infrastructure.Repositories
{
    public class OrderRepository : GenericRepository, IOrderRepository
    {
        public OrderRepository(IDataAccess dataAccess) : base(dataAccess)
        {
        }

        public async Task<TData> GetOrdersByCompanyAsync<TData>(int idEmpresa, int? idSucursal = null, int? idCatEstadoPedido = null) where TData : class, new()
        {
            var parameters = new Dictionary<string, object>
            {
                { "idEmpresa", idEmpresa }
            };

            if (idSucursal.HasValue) parameters["idSucursal"] = idSucursal.Value;
            if (idCatEstadoPedido.HasValue) parameters["idCatEstadoPedido"] = idCatEstadoPedido.Value;

            return await ResolveSpAsync<TData>(parameters);
        }

        public async Task<TData> GetOrderByIdAsync<TData>(int idPedido) where TData : class, new()
        {
            return await ResolveSpAsync<TData>(new Dictionary<string, object> { { "idPedido", idPedido } });
        }

        public async Task<TData> CreateOrderAsync<TData>(object @params) where TData : class, new()
        {
            return await ResolveSpAsync<TData>(@params);
        }

        public async Task<EmptyDto> UpdateOrderStatusAsync(object @params)
        {
            return await ResolveSpAsync<EmptyDto>(@params);
        }
    }
}
