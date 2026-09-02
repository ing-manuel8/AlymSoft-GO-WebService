using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AlymSoftGo.Application.Interfaces;
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

        [HttpGet("company/{idEmpresa:int}")]
        public async Task<IActionResult> GetCategories(int idEmpresa)
        {
            var response = await _categoryService.GetCategoriesAsync<JArray>(idEmpresa);
            return HandleResponse(response);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SaveCategory([FromBody] object categoryParams)
        {
            var response = await _categoryService.SaveCategoryAsync(categoryParams);
            return HandleResponse(response);
        }

        [HttpDelete("{idCategoria:int}/company/{idEmpresa:int}")]
        [Authorize]
        public async Task<IActionResult> DeleteCategory(int idCategoria, int idEmpresa)
        {
            var response = await _categoryService.DeleteCategoryAsync(idCategoria, idEmpresa, CurrentUserIdentifier);
            return HandleResponse(response);
        }
    }
}
