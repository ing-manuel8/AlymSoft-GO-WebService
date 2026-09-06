using AlymSoftGo.Domain.DTOs;

namespace AlymSoftGo.Domain.Interfaces.Repositories
{
    public interface IAuthRepository
    {
        /// <summary>
        /// Login a the user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<UserDto> LoginAsync(LoginRequestDto request);

        /// <summary>
        /// Register a the user
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<UserDto> RegisterAsync(RegisterRequestDto request);

        /// <summary>
        /// Save the refresh token
        /// </summary>
        /// <param name="companyId"></param>
        /// <param name="email"></param>
        /// <param name="refreshToken"></param>
        /// <param name="expirationDate"></param>
        /// <returns></returns>
        Task<EmptyDto> SaveRefreshTokenAsync(int companyId, string email, string refreshToken, DateTime expirationDate);

        /// <summary>
        /// Validate the refresh token
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <returns></returns>
        Task<UserDto> ValidateRefreshTokenAsync(string refreshToken);
        
        /// <summary>
        /// Revoke the refresh token
        /// </summary>
        /// <param name="refreshToken"></param>
        /// <param name="updatedUser"></param>
        /// <returns></returns>
        Task<EmptyDto> RevokeRefreshTokenAsync(string refreshToken, string updatedUser);
    }
}
