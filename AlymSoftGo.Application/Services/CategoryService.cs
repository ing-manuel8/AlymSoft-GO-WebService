using AlymSoftGo.Application.Interfaces;
using AlymSoftGo.Domain.Common;
using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.DTOs.Category;
using AlymSoftGo.Domain.Interfaces.Repositories;
using AlymSoftGo.Domain.Interfaces.Services;
using AlymSoftGo.Domain.Params.Category;

namespace AlymSoftGo.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserContextService _userContext;

        public CategoryService(ICategoryRepository categoryRepository, IUserContextService userContext)
        {
            _categoryRepository = categoryRepository;
            _userContext = userContext;
        }

        public async Task<RepositoryResponse<TData>> GetCategoriesAsync<TData>() where TData : class, new()
        {
            var @params = new GetCategoriesParams
            {
                // Empresa y usuario desde contexto
                CompanyId = _userContext.GetCompanyId()
            };

            var data = await _categoryRepository.GetByCompanyAsync<TData>(@params);
            return RepositoryResponse<TData>.FromSuccess(data);
        }

        public async Task<RepositoryResponse<EmptyDto>> SaveCategoryAsync(SaveCategoryRequestDto request)
        {
            var @params = new SaveCategoryParams
            {
                CategoryId = request.CategoryId,
                // Empresa y usuario desde contexto
                CompanyId = _userContext.GetCompanyId(),
                Name = request.Name,
                Description = request.Description,
                User = _userContext.GetUserName()
            };

            var result = await _categoryRepository.SaveAsync(@params);
            return RepositoryResponse<EmptyDto>.FromSuccess(result);
        }

        public async Task<RepositoryResponse<EmptyDto>> DeleteCategoryAsync(int categoryId)
        {
            var @params = new DeleteCategoryParams
            {
                CategoryId = categoryId,
                // Empresa y usuario desde contexto
                CompanyId = _userContext.GetCompanyId(),
                UpdatedUser = _userContext.GetUserName()
            };

            var result = await _categoryRepository.DeleteAsync(@params);
            return RepositoryResponse<EmptyDto>.FromSuccess(result);
        }
    }
}

