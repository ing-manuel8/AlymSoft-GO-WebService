using System.Security.Claims;
using AlymSoftGo.Domain.DTOs;

namespace AlymSoftGo.Domain.Interfaces.Services
{
    public interface ITokenService
    {
        /// <summary>
        /// Generate a pair of tokens (Access Token and Refresh Token) for a user
        /// </summary>
        /// <param name="user">User information</param>
        /// <returns>Tuple with Access Token and Refresh Token</returns>
        (string AccessToken, string RefreshToken) GenerateTokenPair(UserDto user);

        /// <summary>
        /// Generate a pair of tokens (Access Token and Refresh Token) for a user
        /// </summary>
        /// <param name="claims">Claims for the user</param>
        /// <returns>Tuple with Access Token and Refresh Token</returns>
        (string AccessToken, string RefreshToken) GenerateTokenPair(IEnumerable<Claim> claims);
        
        /// <summary>
        /// Generate only the Access Token for a user
        /// </summary>
        /// <param name="user">User information</param>
        /// <returns>Access Token</returns>
        string GenerateAccessToken(UserDto user);
        
        /// <summary>
        /// Generate only the Access Token for a user
        /// </summary>
        /// <param name="claims">Claims for the user</param>
        /// <returns>Access Token</returns>
        string GenerateAccessToken(IEnumerable<Claim> claims);
        
        /// <summary>
        /// Generate a Refresh Token
        /// </summary>
        /// <returns>Refresh Token</returns>
        string GenerateRefreshToken();
        ClaimsPrincipal? ValidateToken(string token);
    }
}
