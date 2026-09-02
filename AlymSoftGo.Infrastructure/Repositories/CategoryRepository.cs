using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.Interfaces.Persistence;
using AlymSoftGo.Domain.Interfaces.Repositories;
using AlymSoftGo.Infrastructure.Repositories.Base;

namespace AlymSoftGo.Infrastructure.Repositories
{
    public class CategoryRepository : GenericRepository, ICategoryRepository
    {
        public CategoryRepository(IDataAccess dataAccess) : base(dataAccess)
        {
        }

        public async Task<TData> GetCategoriesByCompanyAsync<TData>(int idEmpresa) where TData : class, new()
        {
            return await ResolveSpAsync<TData>(new Dictionary<string, object> { { "idEmpresa", idEmpresa } });
        }

        public async Task<EmptyDto> SaveCategoryAsync(object @params)
        {
            return await ResolveSpAsync<EmptyDto>(@params);
        }

        public async Task<EmptyDto> DeleteCategoryAsync(int idCategoria, int idEmpresa, string vUpdatedUser)
        {
            var parameters = new Dictionary<string, object>
            {
                { "idCategoria", idCategoria },
                { "idEmpresa", idEmpresa },
                { "vUpdatedUser", vUpdatedUser }
            };

            return await ResolveSpAsync<EmptyDto>(parameters);
        }
    }
}
