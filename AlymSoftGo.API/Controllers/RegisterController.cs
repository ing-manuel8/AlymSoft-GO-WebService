using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AlymSoftGo.Application.Interfaces;
using AlymSoftGo.Domain.DTOs;

namespace AlymSoftGo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RegisterController : BaseController
    {
        private readonly IAuthService _authService;

        public RegisterController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Register a new account and company
        /// </summary>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
        {
            var response = await _authService.RegisterAsync(request);
            return Ok(response);
        }
    }
}
