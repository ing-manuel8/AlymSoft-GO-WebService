using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using AlymSoftGo.Domain.Interfaces.Services;

namespace AlymSoftGo.Infrastructure.Services
{
    public class UserContextService : IUserContextService
    {
        private readonly int? _companyId;
        private readonly int? _userId;
        private readonly string? _email;
        private readonly string? _fullName;
        private readonly string _userIdentifier;

        public UserContextService(IHttpContextAccessor httpContextAccessor)
        {
            if (httpContextAccessor == null)
                throw new ArgumentNullException(nameof(httpContextAccessor));

            var httpUser = httpContextAccessor.HttpContext?.User;

            if (httpUser?.Claims != null)
            {
                // CompanyId (companyId o idEmpresa)
                var companyClaim = httpUser.FindFirst("companyId")?.Value?.Trim() 
                                   ?? httpUser.FindFirst("idEmpresa")?.Value?.Trim();
                if (int.TryParse(companyClaim, out var parsedCompanyId))
                    _companyId = parsedCompanyId;

                // UserId
                var userIdClaim = httpUser.FindFirst("userId")?.Value?.Trim();
                if (int.TryParse(userIdClaim, out var parsedUserId))
                    _userId = parsedUserId;

                // Email / Identificador
                _email = httpUser.FindFirst("email")?.Value?.Trim() 
                         ?? httpUser.FindFirst(ClaimTypes.NameIdentifier)?.Value?.Trim();

                var firstName = httpUser.FindFirst("firstName")?.Value?.Trim() 
                                ?? httpUser.FindFirst(ClaimTypes.GivenName)?.Value?.Trim() 
                                ?? string.Empty;
                var lastName = httpUser.FindFirst("lastName")?.Value?.Trim() 
                               ?? httpUser.FindFirst(ClaimTypes.Surname)?.Value?.Trim() 
                               ?? string.Empty;
                var calculatedFullName = $"{firstName} {lastName}".Trim();
                var nameClaim = httpUser.FindFirst("name")?.Value?.Trim() 
                                ?? httpUser.FindFirst(ClaimTypes.Name)?.Value?.Trim();

                _fullName = !string.IsNullOrWhiteSpace(calculatedFullName) 
                    ? calculatedFullName 
                    : (!string.IsNullOrWhiteSpace(nameClaim) ? nameClaim : null);

                _userIdentifier = _email 
                                  ?? httpUser.FindFirst("sub")?.Value?.Trim() 
                                  ?? "SYSTEM";
            }
            else
            {
                _userIdentifier = "SYSTEM";
            }
        }

        public int? CompanyId => _companyId;

        public int? UserId => _userId;

        public string? Email => _email;

        public string? FullName => _fullName;

        public string UserIdentifier => _userIdentifier;

        public int GetCompanyId()
        {
            return _companyId ?? throw new ArgumentException("CompanyId es requerido pero no está disponible en el contexto del usuario autenticado");
        }

        public int GetUserId()
        {
            return _userId ?? throw new ArgumentException("UserId es requerido pero no está disponible en el contexto del usuario autenticado");
        }

        public string GetUserIdentifier()
        {
            return _userIdentifier;
        }

        public string GetUserName()
        {
            if (!string.IsNullOrWhiteSpace(_fullName))
                return _fullName;

            if (!string.IsNullOrWhiteSpace(_email))
                return _email;

            return _userIdentifier;
        }
    }
}
