using AlymSoftGo.Domain.DTOs;

namespace AlymSoftGo.Domain.Interfaces.Repositories
{
    public interface IBranchRepository
    {
        Task<TData> GetBranchesByCompanyAsync<TData>(int idEmpresa) where TData : class, new();
        Task<TData> GetBranchByIdAsync<TData>(int idSucursal) where TData : class, new();
        Task<EmptyDto> SaveBranchAsync(object @params);
    }
}
