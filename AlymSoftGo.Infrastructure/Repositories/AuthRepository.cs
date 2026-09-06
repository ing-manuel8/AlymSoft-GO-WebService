using AlymSoftGo.Domain.DTOs;
using AlymSoftGo.Domain.Interfaces.Persistence;
using AlymSoftGo.Domain.Interfaces.Repositories;
using AlymSoftGo.Infrastructure.Repositories.Base;

namespace AlymSoftGo.Infrastructure.Repositories
{
    public class AuthRepository : GenericRepository, IAuthRepository
    {
        public AuthRepository(IDataAccess dataAccess) : base(dataAccess)
        {
        }

        public async Task<UserDto> LoginAsync(LoginRequestDto request)
        {
            return await ResolveSpAsync<UserDto>(request);
        }

        public async Task<UserDto> RegisterAsync(RegisterRequestDto request)
        {
            return await ResolveSpAsync<UserDto>(request);
        }

        public async Task<EmptyDto> SaveRefreshTokenAsync(int companyId, string email, string refreshToken, DateTime expirationDate)
        {
            var parameters = new Dictionary<string, object>
            {
                { "idEmpresa", companyId },
                { "vEmail", email },
                { "vRefreshToken", refreshToken },
                { "dFechaExpiracion", expirationDate }
            };

            return await ResolveSpAsync<EmptyDto>(parameters);
        }

        public async Task<UserDto> ValidateRefreshTokenAsync(string refreshToken)
        {
            var parameters = new Dictionary<string, object>
            {
                { "vRefreshToken", refreshToken }
            };

            return await ResolveSpAsync<UserDto>(parameters);
        }

        public async Task<EmptyDto> RevokeRefreshTokenAsync(string refreshToken, string updatedUser)
        {
            var parameters = new Dictionary<string, object>
            {
                { "vRefreshToken", refreshToken },
                { "vUpdatedUser", updatedUser }
            };

            return await ResolveSpAsync<EmptyDto>(parameters);
        }
    }
}
