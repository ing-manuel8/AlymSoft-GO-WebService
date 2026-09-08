using AlymSoftGo.Domain.Common;
using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.DTOs.Category;

namespace AlymSoftGo.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<RepositoryResponse<TData>> GetCategoriesAsync<TData>() where TData : class, new();
        Task<RepositoryResponse<EmptyDto>> SaveCategoryAsync(SaveCategoryRequestDto request);
        Task<RepositoryResponse<EmptyDto>> DeleteCategoryAsync(int categoryId);
    }
}
