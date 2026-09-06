using AlymSoftGo.Application.Interfaces;
using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.Interfaces.Repositories;
using AlymSoftGo.Domain.Interfaces.Services;

namespace AlymSoftGo.Application.Services
{
    public class AuthService : IAuthService
    {
        private const int RefreshTokenExpirationDays = 30;
        private readonly IAuthRepository _authRepository;
        private readonly ITokenService _tokenService;

        public AuthService(IAuthRepository authRepository, ITokenService tokenService)
        {
            _authRepository = authRepository;
            _tokenService = tokenService;
        }
        /// <summary>
        /// Generate a login response for a user
        /// </summary>
        /// <param name="request">Login request</param>
        /// <returns>Login response</returns>
        public async Task<(UserDto User, string AccessToken, string RefreshToken)> LoginAsync(LoginRequestDto request)
        {
            var user = await _authRepository.LoginAsync(request);
            var (accessToken, refreshToken) = _tokenService.GenerateTokenPair(user);

            await _authRepository.SaveRefreshTokenAsync(
                user.CompanyId, 
                user.Email, 
                refreshToken, 
                DateTime.UtcNow.AddDays(RefreshTokenExpirationDays)
            );

            return (user, accessToken, refreshToken);
        }

        /// <summary>
        /// Generate a register response for a user
        /// </summary>
        /// <param name="request">Register request</param>
        /// <returns>Register response</returns>
        public async Task<(UserDto User, string AccessToken, string RefreshToken)> RegisterAsync(RegisterRequestDto request)
        {
            var company = await _authRepository.RegisterAsync(request);
            var (accessToken, refreshToken) = _tokenService.GenerateTokenPair(company);

            await _authRepository.SaveRefreshTokenAsync(
                company.CompanyId, 
                company.Email, 
                refreshToken, 
                DateTime.UtcNow.AddDays(RefreshTokenExpirationDays)
            );

            return (company, accessToken, refreshToken);
        }

        /// <summary>
        /// Generate a refresh token response for a user
        /// </summary>
        /// <param name="refreshToken">Refresh token string</param>
        /// <returns>Refresh token response</returns>
        public async Task<(UserDto User, string AccessToken, string RefreshToken)> RefreshTokenAsync(string refreshToken)
        {
            var user = await _authRepository.ValidateRefreshTokenAsync(refreshToken);
            await _authRepository.RevokeRefreshTokenAsync(refreshToken, user.Email);

            var (newAccessToken, newRefreshToken) = _tokenService.GenerateTokenPair(user);

            await _authRepository.SaveRefreshTokenAsync(
                user.CompanyId, 
                user.Email, 
                newRefreshToken, 
                DateTime.UtcNow.AddDays(RefreshTokenExpirationDays)
            );

            return (user, newAccessToken, newRefreshToken);
        }

        /// <summary>
        /// Revoke a refresh token
        /// </summary>
        /// <param name="refreshToken">Refresh token to revoke</param>
        /// <param name="userIdentifier">User identifier</param>
        /// <returns>Empty response</returns>
        public async Task<EmptyDto> RevokeTokenAsync(string refreshToken, string userIdentifier)
        {
            return await _authRepository.RevokeRefreshTokenAsync(refreshToken, userIdentifier);
        }
    }
}
