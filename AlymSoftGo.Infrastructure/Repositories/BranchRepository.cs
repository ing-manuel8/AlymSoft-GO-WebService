using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.Interfaces.Persistence;
using AlymSoftGo.Domain.Interfaces.Repositories;
using AlymSoftGo.Infrastructure.Repositories.Base;

namespace AlymSoftGo.Infrastructure.Repositories
{
    public class BranchRepository : GenericRepository, IBranchRepository
    {
        public BranchRepository(IDataAccess dataAccess) : base(dataAccess)
        {
        }

        public async Task<TData> GetBranchesByCompanyAsync<TData>(int idEmpresa) where TData : class, new()
        {
            return await ResolveSpAsync<TData>(new Dictionary<string, object> { { "idEmpresa", idEmpresa } });
        }

        public async Task<TData> GetBranchByIdAsync<TData>(int idSucursal) where TData : class, new()
        {
            return await ResolveSpAsync<TData>(new Dictionary<string, object> { { "idSucursal", idSucursal } });
        }

        public async Task<EmptyDto> SaveBranchAsync(object @params)
        {
            return await ResolveSpAsync<EmptyDto>(@params);
        }
    }
}
