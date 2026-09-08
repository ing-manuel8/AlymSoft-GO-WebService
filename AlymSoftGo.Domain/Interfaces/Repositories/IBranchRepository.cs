using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.Params.Branch;

namespace AlymSoftGo.Domain.Interfaces.Repositories
{
    public interface IBranchRepository
    {
        Task<TData> GetBranchesByCompanyAsync<TData>(GetBranchesParams @params) where TData : class, new();
        Task<TData> GetBranchByIdAsync<TData>(GetBranchByIdParams @params) where TData : class, new();
        Task<List<AlymSoftGo.Domain.DTOs.Branch.BranchUserDto>> GetAssignableUsersAsync(GetBranchUsersParams @params);
        Task<EmptyDto> SaveAsync(SaveBranchParams @params);
        Task<EmptyDto> DeleteAsync(DeleteBranchParams @params);
    }
}
