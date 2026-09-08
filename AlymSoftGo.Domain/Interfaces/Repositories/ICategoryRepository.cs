using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.Params.Category;

namespace AlymSoftGo.Domain.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<TData> GetByCompanyAsync<TData>(GetCategoriesParams @params) where TData : class, new();
        Task<EmptyDto> SaveAsync(SaveCategoryParams @params);
        Task<EmptyDto> DeleteAsync(DeleteCategoryParams @params);
    }
}
