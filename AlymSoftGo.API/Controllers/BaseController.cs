using Microsoft.AspNetCore.Mvc;
using AlymSoftGo.Domain.Common;

namespace AlymSoftGo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseController : ControllerBase
    {
        protected int CurrentCompanyId
        {
            get
            {
                var claim = User.FindFirst("companyId") ?? User.FindFirst("idEmpresa");
                return claim != null && int.TryParse(claim.Value, out var id) ? id : 0;
            }
        }

        protected string CurrentUserIdentifier
        {
            get
            {
                var claim = User.FindFirst("email") ?? User.FindFirst("sub") ?? User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier);
                return claim?.Value ?? "SYSTEM";
            }
        }

        protected IActionResult HandleResponse<T>(RepositoryResponse<T> response)
        {
            if (response.IsSuccess)
            {
                return Ok(response.Data);
            }

            return StatusCode(500, new
            {
                responseCode = response.ResponseCode.ToString(),
                message = response.Message,
                errors = response.Errors
            });
        }

        protected IActionResult HandleSuccess(object? data = null, string message = "Operation successful")
        {
            return Ok(data);
        }
    }
}
