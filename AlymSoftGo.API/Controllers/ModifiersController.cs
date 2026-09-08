using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AlymSoftGo.Application.Interfaces;
using AlymSoftGo.Domain.DTOs.Modifier;

namespace AlymSoftGo.API.Controllers
{
    [Authorize]
    public class ModifiersController : BaseController
    {
        private readonly IModifierService _modifierService;

        public ModifiersController(IModifierService modifierService)
        {
            _modifierService = modifierService;
        }

        [HttpGet]
        public async Task<IActionResult> GetGroups()
        {
            var response = await _modifierService.GetGroupsByCompanyAsync();
            return HandleResponse(response);
        }

        [HttpGet("product/{productId:int}")]
        public async Task<IActionResult> GetGroupsByProduct(int productId)
        {
            var response = await _modifierService.GetGroupsByProductAsync(productId);
            return HandleResponse(response);
        }

        [HttpPost("group")]
        public async Task<IActionResult> SaveGroup([FromBody] SaveModifierGroupRequestDto request)
        {
            var response = await _modifierService.SaveGroupAsync(request);
            return HandleResponse(response);
        }

        [HttpDelete("group/{groupId:int}")]
        public async Task<IActionResult> DeleteGroup(int groupId)
        {
            var response = await _modifierService.DeleteGroupAsync(groupId);
            return HandleResponse(response);
        }

        [HttpPost("assign-product")]
        public async Task<IActionResult> AssignProductGroups([FromBody] AssignProductModifiersRequestDto request)
        {
            var response = await _modifierService.AssignProductGroupsAsync(request);
            return HandleResponse(response);
        }
    }
}
