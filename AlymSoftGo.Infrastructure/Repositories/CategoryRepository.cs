using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.Interfaces.Persistence;
using AlymSoftGo.Domain.Interfaces.Repositories;
using AlymSoftGo.Domain.Params.Category;
using AlymSoftGo.Infrastructure.Repositories.Base;

namespace AlymSoftGo.Infrastructure.Repositories
{
    public class CategoryRepository : GenericRepository, ICategoryRepository
    {
        public CategoryRepository(IDataAccess dataAccess) : base(dataAccess)
        {
        }

        public async Task<TData> GetByCompanyAsync<TData>(GetCategoriesParams @params) where TData : class, new()
        {
            return await ResolveSpAsync<TData>(@params);
        }

        public async Task<EmptyDto> SaveAsync(SaveCategoryParams @params)
        {
            return await ResolveSpAsync<EmptyDto>(@params);
        }

        public async Task<EmptyDto> DeleteAsync(DeleteCategoryParams @params)
        {
            return await ResolveSpAsync<EmptyDto>(@params);
        }
    }
}
