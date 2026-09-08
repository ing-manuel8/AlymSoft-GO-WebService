using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AlymSoftGo.Application.Interfaces;
using AlymSoftGo.Domain.DTOs.Branch;

namespace AlymSoftGo.API.Controllers
{
    [Authorize]
    public class BranchesController : BaseController
    {
        private readonly IBranchService _branchService;

        public BranchesController(IBranchService branchService)
        {
            _branchService = branchService;
        }

        [HttpGet]
        public async Task<IActionResult> GetBranches()
        {
            var response = await _branchService.GetBranchesAsync();
            return HandleResponse(response);
        }

        [HttpGet("{branchId:int}")]
        public async Task<IActionResult> GetBranchById(int branchId)
        {
            var response = await _branchService.GetBranchByIdAsync(branchId);
            return HandleResponse(response);
        }

        [HttpGet("users")]
        public async Task<IActionResult> GetAssignableUsers()
        {
            var response = await _branchService.GetAssignableUsersAsync();
            return HandleResponse(response);
        }

        [HttpPost]
        public async Task<IActionResult> SaveBranch([FromBody] SaveBranchRequestDto request)
        {
            var response = await _branchService.SaveBranchAsync(request);
            return HandleResponse(response);
        }

        [HttpDelete("{branchId:int}")]
        public async Task<IActionResult> DeleteBranch(int branchId)
        {
            var response = await _branchService.DeleteBranchAsync(branchId);
            return HandleResponse(response);
        }
    }
}
