using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AlymSoftGo.Application.Interfaces;
using AlymSoftGo.Domain.DTOs;

namespace AlymSoftGo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : BaseController
    {
        private readonly IAuthService _authService;

        public LoginController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Authenticate user and return AccessToken and RefreshToken
        /// </summary>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var response = await _authService.LoginAsync(request);
            return Ok(response);
        }

        /// <summary>
        /// Refresh expired AccessToken using a valid RefreshToken
        /// </summary>
        [HttpPost("refresh")]
        [AllowAnonymous]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestDto request)
        {
            var response = await _authService.RefreshTokenAsync(request);
            return Ok(response);
        }

        /// <summary>
        /// Revoke RefreshToken (Logout)
        /// </summary>
        [HttpPost("revoke")]
        [Authorize]
        public async Task<IActionResult> RevokeToken([FromBody] RefreshTokenRequestDto request)
        {
            await _authService.RevokeTokenAsync(request.RefreshToken, CurrentUserIdentifier);
            return Ok(new { message = "Token revoked successfully." });
        }
    }
}
