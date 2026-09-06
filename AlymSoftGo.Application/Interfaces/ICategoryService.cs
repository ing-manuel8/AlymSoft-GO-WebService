using AlymSoftGo.Domain.Common;
using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.Params.Category;

namespace AlymSoftGo.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<RepositoryResponse<TData>> GetCategoriesAsync<TData>(GetCategoriesParams @params) where TData : class, new();
        Task<RepositoryResponse<EmptyDto>> SaveCategoryAsync(SaveCategoryParams @params);
        Task<RepositoryResponse<EmptyDto>> DeleteCategoryAsync(DeleteCategoryParams @params);
    }
}
