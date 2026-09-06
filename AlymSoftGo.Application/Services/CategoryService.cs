using AlymSoftGo.Application.Interfaces;
using AlymSoftGo.Domain.Common;
using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.Interfaces.Repositories;
using AlymSoftGo.Domain.Params.Category;

namespace AlymSoftGo.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<RepositoryResponse<TData>> GetCategoriesAsync<TData>(GetCategoriesParams @params) where TData : class, new()
        {
            var data = await _categoryRepository.GetCategoriesByCompanyAsync<TData>(@params);
            return RepositoryResponse<TData>.FromSuccess(data);
        }

        public async Task<RepositoryResponse<EmptyDto>> SaveCategoryAsync(SaveCategoryParams @params)
        {
            var result = await _categoryRepository.SaveCategoryAsync(@params);
            return RepositoryResponse<EmptyDto>.FromSuccess(result);
        }

        public async Task<RepositoryResponse<EmptyDto>> DeleteCategoryAsync(DeleteCategoryParams @params)
        {
            var result = await _categoryRepository.DeleteCategoryAsync(@params);
            return RepositoryResponse<EmptyDto>.FromSuccess(result);
        }
    }
}
