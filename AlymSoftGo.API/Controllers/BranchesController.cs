using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AlymSoftGo.Application.Interfaces;

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
    }
}
