using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.Interfaces.Persistence;
using AlymSoftGo.Domain.Interfaces.Repositories;
using AlymSoftGo.Infrastructure.Repositories.Base;

namespace AlymSoftGo.Infrastructure.Repositories
{
    public class CompanyRepository : GenericRepository, ICompanyRepository
    {
        public CompanyRepository(IDataAccess dataAccess) : base(dataAccess)
        {
        }

        public async Task<TData> GetCompanyByIdAsync<TData>(int idEmpresa) where TData : class, new()
        {
            return await ResolveSpAsync<TData>(new Dictionary<string, object> { { "idEmpresa", idEmpresa } });
        }

        public async Task<TData> GetCompanyBySlugAsync<TData>(string vDominioSlug) where TData : class, new()
        {
            return await ResolveSpAsync<TData>(new Dictionary<string, object> { { "vDominioSlug", vDominioSlug } });
        }

        public async Task<EmptyDto> SaveCompanyAsync(object @params)
        {
            return await ResolveSpAsync<EmptyDto>(@params);
        }
    }
}
