using AlymSoftGo.Application.Interfaces;
using AlymSoftGo.Domain.Common;
using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.Interfaces.Repositories;

namespace AlymSoftGo.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<RepositoryResponse<TData>> GetCategoriesAsync<TData>(int idEmpresa) where TData : class, new()
        {
            var data = await _categoryRepository.GetCategoriesByCompanyAsync<TData>(idEmpresa);
            return RepositoryResponse<TData>.FromSuccess(data);
        }

        public async Task<RepositoryResponse<EmptyDto>> SaveCategoryAsync(object @params)
        {
            var result = await _categoryRepository.SaveCategoryAsync(@params);
            return RepositoryResponse<EmptyDto>.FromSuccess(result, "Category saved successfully.");
        }

        public async Task<RepositoryResponse<EmptyDto>> DeleteCategoryAsync(int idCategoria, int idEmpresa, string vUpdatedUser)
        {
            var result = await _categoryRepository.DeleteCategoryAsync(idCategoria, idEmpresa, vUpdatedUser);
            return RepositoryResponse<EmptyDto>.FromSuccess(result, "Category deleted successfully.");
        }
    }
}
