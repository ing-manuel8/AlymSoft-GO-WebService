using System.Security.Claims;

namespace AlymSoftGo.Domain.Interfaces.Services
{
    public interface ITokenService
    {
        (string AccessToken, string RefreshToken) GenerateTokenPair(int companyId, string userIdentifier, IEnumerable<Claim>? additionalClaims = null);
        string GenerateAccessToken(int companyId, string userIdentifier, IEnumerable<Claim>? additionalClaims = null);
        string GenerateRefreshToken();
        ClaimsPrincipal? ValidateToken(string token);
    }
}
