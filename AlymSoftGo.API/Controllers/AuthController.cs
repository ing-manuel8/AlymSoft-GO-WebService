using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using AlymSoftGo.Application.Interfaces;
using AlymSoftGo.Domain.DTOs;

namespace AlymSoftGo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Route("api/Login")]
    public class AuthController : BaseController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <summary>
        /// Authenticate user and return user data (tokens in HttpOnly cookies)
        /// </summary>
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto request)
        {
            var (user, accessToken, refreshToken) = await _authService.LoginAsync(request);
            SetTokenCookies(accessToken, refreshToken);
            return Ok(user);
        }

        /// <summary>
        /// Register a new account and company (tokens in HttpOnly cookies)
        /// </summary>
        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto request)
        {
            var (user, accessToken, refreshToken) = await _authService.RegisterAsync(request);
            SetTokenCookies(accessToken, refreshToken);
            return Ok(user);
        }

        /// <summary>
        /// Refresh expired AccessToken using a valid RefreshToken
        /// </summary>
        [HttpPost("refresh")]
        [HttpPost("refresh-token")]
        [AllowAnonymous]
        public async Task<IActionResult> RefreshToken([FromBody] RefreshTokenRequestDto? request)
        {
            var tokenStr = request?.RefreshToken;
            if (string.IsNullOrEmpty(tokenStr) && Request.Cookies.TryGetValue("refreshToken", out var cookieToken))
            {
                tokenStr = cookieToken;
            }

            if (string.IsNullOrEmpty(tokenStr))
            {
                return Unauthorized(new { message = "RefreshToken is required" });
            }

            var (user, accessToken, newRefreshToken) = await _authService.RefreshTokenAsync(tokenStr);
            SetTokenCookies(accessToken, newRefreshToken);
            return Ok(user);
        }

        /// <summary>
        /// Revoke RefreshToken (Logout)
        /// </summary>
        [HttpPost("revoke")]
        [Authorize]
        public async Task<IActionResult> RevokeToken([FromBody] RefreshTokenRequestDto? request)
        {
            var tokenStr = request?.RefreshToken;
            if (string.IsNullOrEmpty(tokenStr) && Request.Cookies.TryGetValue("refreshToken", out var cookieToken))
            {
                tokenStr = cookieToken;
            }

            if (!string.IsNullOrEmpty(tokenStr))
            {
                await _authService.RevokeTokenAsync(tokenStr, CurrentUserIdentifier);
            }

            DeleteTokenCookies();
            return Ok(new { message = "Token revoked successfully." });
        }

        private void SetTokenCookies(string accessToken, string refreshToken)
        {
            var isHttps = Request.IsHttps;
            var accessOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = isHttps,
                SameSite = isHttps ? SameSiteMode.None : SameSiteMode.Lax,
                Expires = DateTime.UtcNow.AddMinutes(60)
            };
            Response.Cookies.Append("accessToken", accessToken, accessOptions);

            var refreshOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = isHttps,
                SameSite = isHttps ? SameSiteMode.None : SameSiteMode.Lax,
                Expires = DateTime.UtcNow.AddDays(30)
            };
            Response.Cookies.Append("refreshToken", refreshToken, refreshOptions);
        }

        private void DeleteTokenCookies()
        {
            Response.Cookies.Delete("accessToken");
            Response.Cookies.Delete("refreshToken");
        }

        /// <summary>
        /// Get current authenticated user profile directly from JWT claims (without returning tokens)
        /// </summary>
        [HttpGet("me")]
        [Authorize]
        public IActionResult GetMe()
        {
            var user = new UserDto
            {
                UserId = int.TryParse(User.FindFirst("userId")?.Value, out var uid) ? uid : 0,
                CompanyId = CurrentCompanyId,
                CompanyName = User.FindFirst("companyName")?.Value ?? string.Empty,
                Currency = User.FindFirst("currency")?.Value ?? "USD",
                BranchId = int.TryParse(User.FindFirst("branchId")?.Value, out var bid) ? bid : null,
                BranchName = User.FindFirst("branchName")?.Value,
                TimeZone = User.FindFirst("timeZone")?.Value,
                TimeZoneIANA = User.FindFirst("timeZoneIANA")?.Value,
                Email = User.FindFirst("email")?.Value ?? CurrentUserIdentifier,
                FirstName = User.FindFirst("firstName")?.Value ?? string.Empty,
                LastName = User.FindFirst("lastName")?.Value,
                Phone = User.FindFirst("phone")?.Value,
                IsSuperAdmin = bool.TryParse(User.FindFirst("isSuperAdmin")?.Value, out var isa) && isa,
                RoleId = int.TryParse(User.FindFirst("roleId")?.Value, out var rid) ? rid : null,
                RoleName = User.FindFirst("roleName")?.Value,
                Permissions = User.FindFirst("permissions")?.Value
            };

            return Ok(user);
        }
    }
}
