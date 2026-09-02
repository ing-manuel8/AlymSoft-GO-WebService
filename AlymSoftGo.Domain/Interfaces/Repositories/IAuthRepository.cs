using AlymSoftGo.Domain.DTOs;

namespace AlymSoftGo.Domain.Interfaces.Repositories
{
    public interface IAuthRepository
    {
        Task<LoginResponseDto> LoginAsync(LoginRequestDto request);
        Task<RegisterResponseDto> RegisterAsync(RegisterRequestDto request);
        Task<EmptyDto> SaveRefreshTokenAsync(int companyId, string email, string refreshToken, DateTime expirationDate);
        Task<LoginResponseDto> ValidateRefreshTokenAsync(string refreshToken);
        Task<EmptyDto> RevokeRefreshTokenAsync(string refreshToken, string updatedUser);
    }
}
