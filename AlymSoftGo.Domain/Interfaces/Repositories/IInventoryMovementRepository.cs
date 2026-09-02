using AlymSoftGo.Domain.DTOs;

namespace AlymSoftGo.Domain.Interfaces.Repositories
{
    public interface IInventoryMovementRepository
    {
        Task<TData> GetMovementsByProductAsync<TData>(int idEmpresa, int idProducto, int? idSucursal = null) where TData : class, new();
        Task<EmptyDto> RegisterMovementAsync(object @params);
    }
}
