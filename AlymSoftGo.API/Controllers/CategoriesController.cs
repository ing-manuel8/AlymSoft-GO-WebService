using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AlymSoftGo.Application.Interfaces;
using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.Params.Category;
using Newtonsoft.Json.Linq;

namespace AlymSoftGo.API.Controllers
{
    public class CategoriesController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet("company/{companyId:int}")]
        public async Task<IActionResult> GetCategories(int companyId)
        {
            var @params = new GetCategoriesParams
            {
                CompanyId = companyId
            };
            var response = await _categoryService.GetCategoriesAsync<List<CategoryDto>>(@params);
            return HandleResponse(response);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SaveCategory([FromBody] SaveCategoryRequestDto request)
        {
            var @params = new SaveCategoryParams
            {
                CategoryId = request.CategoryId,
                CompanyId = request.CompanyId,
                Name = request.Name,
                Description = request.Description,
                User = !string.IsNullOrEmpty(request.User) && request.User != "SYSTEM" ? request.User : CurrentUserIdentifier
            };
            var response = await _categoryService.SaveCategoryAsync(@params);
            return HandleResponse(response);
        }

        [HttpDelete("{categoryId:int}/company/{companyId:int}")]
        [Authorize]
        public async Task<IActionResult> DeleteCategory(int categoryId, int companyId)
        {
            var @params = new DeleteCategoryParams
            {
                CategoryId = categoryId,
                CompanyId = companyId,
                UpdatedUser = CurrentUserIdentifier
            };
            var response = await _categoryService.DeleteCategoryAsync(@params);
            return HandleResponse(response);
        }
    }
}
