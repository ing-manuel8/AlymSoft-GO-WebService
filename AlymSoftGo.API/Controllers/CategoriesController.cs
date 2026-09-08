using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AlymSoftGo.Application.Interfaces;
using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.DTOs.Category;

namespace AlymSoftGo.API.Controllers
{
    public class CategoriesController : BaseController
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        [HttpGet("company/{companyId:int}")]
        public async Task<IActionResult> GetCategories()
        {
            var response = await _categoryService.GetCategoriesAsync<List<CategoryDto>>();
            return HandleResponse(response);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SaveCategory([FromBody] SaveCategoryRequestDto request)
        {
            var response = await _categoryService.SaveCategoryAsync(request);
            return HandleResponse(response);
        }

        [HttpDelete("{categoryId:int}")]
        [HttpDelete("{categoryId:int}/company/{companyId:int}")]
        [Authorize]
        public async Task<IActionResult> DeleteCategory(int categoryId)
        {
            var response = await _categoryService.DeleteCategoryAsync(categoryId);
            return HandleResponse(response);
        }
    }
}

