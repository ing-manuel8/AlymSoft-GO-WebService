using AlymSoftGo.Domain.DTOs;

namespace AlymSoftGo.Application.Interfaces
{
    public interface IAuthService
    {
        Task<(UserDto User, string AccessToken, string RefreshToken)> LoginAsync(LoginRequestDto request);
        Task<(UserDto User, string AccessToken, string RefreshToken)> RegisterAsync(RegisterRequestDto request);
        Task<(UserDto User, string AccessToken, string RefreshToken)> RefreshTokenAsync(string refreshToken);
        Task<EmptyDto> RevokeTokenAsync(string refreshToken, string userIdentifier);
    }
}
