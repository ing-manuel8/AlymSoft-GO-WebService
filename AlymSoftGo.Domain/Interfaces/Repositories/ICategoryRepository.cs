using AlymSoftGo.Domain.DTOs;

namespace AlymSoftGo.Domain.Interfaces.Repositories
{
    public interface ICategoryRepository
    {
        Task<TData> GetCategoriesByCompanyAsync<TData>(int idEmpresa) where TData : class, new();
        Task<EmptyDto> SaveCategoryAsync(object @params);
        Task<EmptyDto> DeleteCategoryAsync(int idCategoria, int idEmpresa, string vUpdatedUser);
    }
}
