using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.Interfaces.Services;

namespace AlymSoftGo.Infrastructure.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;

        public TokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public (string AccessToken, string RefreshToken) GenerateTokenPair(UserDto user)
        {
            var accessToken = GenerateAccessToken(user);
            var refreshToken = GenerateRefreshToken();
            return (accessToken, refreshToken);
        }

        public (string AccessToken, string RefreshToken) GenerateTokenPair(IEnumerable<Claim> claims)
        {
            var accessToken = GenerateAccessToken(claims);
            var refreshToken = GenerateRefreshToken();
            return (accessToken, refreshToken);
        }

        public string GenerateAccessToken(UserDto user)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.Email),
                new("sub", user.Email),
                new("companyId", user.CompanyId.ToString()),
                new("idEmpresa", user.CompanyId.ToString()),
                new("userId", user.UserId.ToString()),
                new("companyName", user.CompanyName ?? string.Empty),
                new("currency", user.Currency ?? "USD"),
                new("email", user.Email ?? string.Empty),
                new("firstName", user.FirstName ?? string.Empty),
                new("lastName", user.LastName ?? string.Empty),
                new(ClaimTypes.Name, $"{user.FirstName} {user.LastName}".Trim()),
                new("name", $"{user.FirstName} {user.LastName}".Trim()),
                new("phone", user.Phone ?? string.Empty),
                new("isSuperAdmin", user.IsSuperAdmin.ToString())
            };

            if (user.BranchId.HasValue) claims.Add(new("branchId", user.BranchId.Value.ToString()));
            if (!string.IsNullOrEmpty(user.BranchName)) claims.Add(new("branchName", user.BranchName));
            if (!string.IsNullOrEmpty(user.TimeZone)) claims.Add(new("timeZone", user.TimeZone));
            if (!string.IsNullOrEmpty(user.TimeZoneIANA)) claims.Add(new("timeZoneIANA", user.TimeZoneIANA));
            if (user.RoleId.HasValue) claims.Add(new("roleId", user.RoleId.Value.ToString()));
            if (!string.IsNullOrEmpty(user.RoleName)) claims.Add(new("roleName", user.RoleName));
            if (!string.IsNullOrEmpty(user.Permissions)) claims.Add(new("permissions", user.Permissions));

            return GenerateAccessToken(claims);
        }

        public string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"] 
                ?? throw new InvalidOperationException("JwtSettings:SecretKey is not configured.");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Access Token corta duración (por defecto 60 minutos)
            var expirationMinutes = double.TryParse(jwtSettings["AccessTokenExpirationMinutes"], out var minutes) ? minutes : 60;

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(expirationMinutes),
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public string GenerateRefreshToken()
        {
            var randomBytes = new byte[64];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomBytes);
            return Convert.ToBase64String(randomBytes);
        }

        public ClaimsPrincipal? ValidateToken(string token)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"] 
                ?? throw new InvalidOperationException("JwtSettings:SecretKey is not configured.");

            var tokenHandler = new JwtSecurityTokenHandler();
            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = jwtSettings["Issuer"],
                ValidAudience = jwtSettings["Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
                ClockSkew = TimeSpan.Zero
            };

            try
            {
                return tokenHandler.ValidateToken(token, validationParameters, out _);
            }
            catch
            {
                return null;
            }
        }
    }
}
