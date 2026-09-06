using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.Params.Category;

namespace AlymSoftGo.Domain.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<TData> GetCategoriesByCompanyAsync<TData>(GetCategoriesParams @params) where TData : class, new();
        Task<EmptyDto> SaveCategoryAsync(SaveCategoryParams @params);
        Task<EmptyDto> DeleteCategoryAsync(DeleteCategoryParams @params);
    }
}
