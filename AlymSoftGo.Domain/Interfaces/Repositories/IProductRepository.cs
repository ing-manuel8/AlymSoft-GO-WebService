using AlymSoftGo.Domain.DTOs;

namespace AlymSoftGo.Domain.Interfaces.Repositories
{
    public interface IProductRepository
    {
        Task<TData> GetProductsByCompanyAsync<TData>(int idEmpresa, int? idCategoria = null, int? idSucursal = null) where TData : class, new();
        Task<TData> GetProductByIdAsync<TData>(int idProducto, int? idSucursal = null) where TData : class, new();
        Task<EmptyDto> SaveProductAsync(object @params);
        Task<EmptyDto> DeleteProductAsync(int idProducto, int idEmpresa, string vUpdatedUser);
    }
}
