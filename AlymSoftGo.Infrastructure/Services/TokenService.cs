using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
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

        public (string AccessToken, string RefreshToken) GenerateTokenPair(int companyId, string userIdentifier, IEnumerable<Claim>? additionalClaims = null)
        {
            var accessToken = GenerateAccessToken(companyId, userIdentifier, additionalClaims);
            var refreshToken = GenerateRefreshToken();
            return (accessToken, refreshToken);
        }

        public string GenerateAccessToken(int companyId, string userIdentifier, IEnumerable<Claim>? additionalClaims = null)
        {
            var jwtSettings = _configuration.GetSection("JwtSettings");
            var secretKey = jwtSettings["SecretKey"] 
                ?? throw new InvalidOperationException("JwtSettings:SecretKey is not configured.");

            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, userIdentifier),
                new("sub", userIdentifier),
                new("companyId", companyId.ToString()),
                new("idEmpresa", companyId.ToString())
            };

            if (additionalClaims != null)
            {
                claims.AddRange(additionalClaims);
            }

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
