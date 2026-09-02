using AlymSoftGo.Domain.Common;
using AlymSoftGo.Domain.DTOs;

namespace AlymSoftGo.Application.Interfaces
{
    public interface ICategoryService
    {
        Task<RepositoryResponse<TData>> GetCategoriesAsync<TData>(int idEmpresa) where TData : class, new();
        Task<RepositoryResponse<EmptyDto>> SaveCategoryAsync(object @params);
        Task<RepositoryResponse<EmptyDto>> DeleteCategoryAsync(int idCategoria, int idEmpresa, string vUpdatedUser);
    }
}
