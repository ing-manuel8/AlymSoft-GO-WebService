namespace AlymSoftGo.Domain.Interfaces.Services
{
    public interface IUserContextService
    {
        int? CompanyId { get; }
        int? UserId { get; }
        string? Email { get; }
        string? FullName { get; }
        string UserIdentifier { get; }

        /// <summary>
        /// Obtiene el CompanyId asegurando que no sea null desde los claims JWT
        /// </summary>
        int GetCompanyId();

        /// <summary>
        /// Obtiene el UserId asegurando que no sea null desde los claims JWT
        /// </summary>
        int GetUserId();

        /// <summary>
        /// Obtiene el identificador del usuario autenticado (Email, sub o SYSTEM)
        /// </summary>
        string GetUserIdentifier();

        /// <summary>
        /// Obtiene el nombre completo del usuario autenticado para auditoría
        /// </summary>
        string GetUserName();
    }
}
