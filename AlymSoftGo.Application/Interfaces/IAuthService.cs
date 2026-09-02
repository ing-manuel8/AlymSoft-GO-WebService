using AlymSoftGo.Domain.DTOs;

namespace AlymSoftGo.Application.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponseDto> LoginAsync(LoginRequestDto request);
        Task<RegisterResponseDto> RegisterAsync(RegisterRequestDto request);
        Task<RefreshTokenResponseDto> RefreshTokenAsync(RefreshTokenRequestDto request);
        Task<EmptyDto> RevokeTokenAsync(string refreshToken, string userIdentifier);
    }
}
