using AlymSoftGo.Domain.Common;
using AlymSoftGo.Domain.DTOs;

namespace AlymSoftGo.Application.Interfaces
{
    public interface IProductService
    {
        Task<RepositoryResponse<TData>> GetProductsAsync<TData>(int idEmpresa, int? idCategoria = null, int? idSucursal = null) where TData : class, new();
        Task<RepositoryResponse<TData>> GetProductByIdAsync<TData>(int idProducto, int? idSucursal = null) where TData : class, new();
        Task<RepositoryResponse<EmptyDto>> SaveProductAsync(object @params);
        Task<RepositoryResponse<EmptyDto>> DeleteProductAsync(int idProducto, int idEmpresa, string vUpdatedUser);
    }
}
