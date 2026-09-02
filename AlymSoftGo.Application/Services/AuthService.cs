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

        public async Task<LoginResponseDto> LoginAsync(LoginRequestDto request)
        {
            var user = await _authRepository.LoginAsync(request);
            var (accessToken, refreshToken) = _tokenService.GenerateTokenPair(user.CompanyId, user.Email);

            await _authRepository.SaveRefreshTokenAsync(
                user.CompanyId, 
                user.Email, 
                refreshToken, 
                DateTime.UtcNow.AddDays(RefreshTokenExpirationDays)
            );

            user.AccessToken = accessToken;
            user.RefreshToken = refreshToken;

            return user;
        }

        public async Task<RegisterResponseDto> RegisterAsync(RegisterRequestDto request)
        {
            var company = await _authRepository.RegisterAsync(request);
            var (accessToken, refreshToken) = _tokenService.GenerateTokenPair(company.CompanyId, request.Email);

            await _authRepository.SaveRefreshTokenAsync(
                company.CompanyId, 
                request.Email, 
                refreshToken, 
                DateTime.UtcNow.AddDays(RefreshTokenExpirationDays)
            );

            company.AccessToken = accessToken;
            company.RefreshToken = refreshToken;

            return company;
        }

        public async Task<RefreshTokenResponseDto> RefreshTokenAsync(RefreshTokenRequestDto request)
        {
            var user = await _authRepository.ValidateRefreshTokenAsync(request.RefreshToken);
            await _authRepository.RevokeRefreshTokenAsync(request.RefreshToken, user.Email);

            var (newAccessToken, newRefreshToken) = _tokenService.GenerateTokenPair(user.CompanyId, user.Email);

            await _authRepository.SaveRefreshTokenAsync(
                user.CompanyId, 
                user.Email, 
                newRefreshToken, 
                DateTime.UtcNow.AddDays(RefreshTokenExpirationDays)
            );

            return new RefreshTokenResponseDto
            {
                AccessToken = newAccessToken,
                RefreshToken = newRefreshToken
            };
        }

        public async Task<EmptyDto> RevokeTokenAsync(string refreshToken, string userIdentifier)
        {
            return await _authRepository.RevokeRefreshTokenAsync(refreshToken, userIdentifier);
        }
    }
}
