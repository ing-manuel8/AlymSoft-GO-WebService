using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.Interfaces.Persistence;
using AlymSoftGo.Domain.Interfaces.Repositories;
using AlymSoftGo.Infrastructure.Repositories.Base;

namespace AlymSoftGo.Infrastructure.Repositories
{
    public class InventoryMovementRepository : GenericRepository, IInventoryMovementRepository
    {
        public InventoryMovementRepository(IDataAccess dataAccess) : base(dataAccess)
        {
        }

        public async Task<TData> GetMovementsByProductAsync<TData>(int idEmpresa, int idProducto, int? idSucursal = null) where TData : class, new()
        {
            var parameters = new Dictionary<string, object>
            {
                { "idEmpresa", idEmpresa },
                { "idProducto", idProducto }
            };

            if (idSucursal.HasValue) parameters["idSucursal"] = idSucursal.Value;

            return await ResolveSpAsync<TData>(parameters);
        }

        public async Task<EmptyDto> RegisterMovementAsync(object @params)
        {
            return await ResolveSpAsync<EmptyDto>(@params);
        }
    }
}
