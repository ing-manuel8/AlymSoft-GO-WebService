using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.Interfaces.Persistence;
using AlymSoftGo.Domain.Interfaces.Repositories;
using AlymSoftGo.Domain.Params.Branch;
using AlymSoftGo.Infrastructure.Repositories.Base;

namespace AlymSoftGo.Infrastructure.Repositories
{
    public class BranchRepository : GenericRepository, IBranchRepository
    {
        public BranchRepository(IDataAccess dataAccess) : base(dataAccess)
        {
        }

        public async Task<TData> GetBranchesByCompanyAsync<TData>(GetBranchesParams @params) where TData : class, new()
        {
            return await ResolveSpAsync<TData>(@params);
        }

        public async Task<TData> GetBranchByIdAsync<TData>(GetBranchByIdParams @params) where TData : class, new()
        {
            return await ResolveSpAsync<TData>(@params);
        }

        public async Task<List<AlymSoftGo.Domain.DTOs.Branch.BranchUserDto>> GetAssignableUsersAsync(GetBranchUsersParams @params)
        {
            return await ResolveSpAsync<List<AlymSoftGo.Domain.DTOs.Branch.BranchUserDto>>(@params);
        }

        public async Task<EmptyDto> SaveAsync(SaveBranchParams @params)
        {
            return await ResolveSpAsync<EmptyDto>(@params);
        }

        public async Task<EmptyDto> DeleteAsync(DeleteBranchParams @params)
        {
            return await ResolveSpAsync<EmptyDto>(@params);
        }
    }
}
