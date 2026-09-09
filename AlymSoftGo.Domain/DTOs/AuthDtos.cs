using System.ComponentModel.DataAnnotations;

namespace AlymSoftGo.Domain.DTOs
{
    public class LoginRequestDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class UserDto
    {
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string Currency { get; set; } = string.Empty;
        public string Culture { get; set; } = string.Empty;
        public int? BranchId { get; set; }
        public string? BranchName { get; set; }
        public string? TimeZone { get; set; }
        public string? TimeZoneIANA { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string? LastName { get; set; }
        public string? Phone { get; set; }
        public bool IsSuperAdmin { get; set; }
        public int? RoleId { get; set; }
        public string? RoleName { get; set; }
        public string? Permissions { get; set; }
    }

    public class RegisterRequestDto
    {
        [Required(ErrorMessage = "COMPANY_NAME_REQUIRED")]
        public string CompanyName { get; set; } = string.Empty;

        [Required(ErrorMessage = "FIRST_NAME_REQUIRED")]
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "EMAIL_REQUIRED")]
        [EmailAddress(ErrorMessage = "EMAIL_INVALID")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "PASSWORD_REQUIRED")]
        [MinLength(6, ErrorMessage = "PASSWORD_TOO_SHORT")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "PHONE_REQUIRED")]
        public string Phone { get; set; } = string.Empty;

        public string TimeZone { get; set; } = string.Empty;
        public string TimeZoneIANA { get; set; } = string.Empty;

        [Required(ErrorMessage = "CURRENCY_REQUIRED")]
        public string Currency { get; set; } = string.Empty;

        [Required(ErrorMessage = "CULTURE_REQUIRED")]
        public string Culture { get; set; } = string.Empty;
    }

    public class RefreshTokenRequestDto
    {
        public string? RefreshToken { get; set; }
    }
}
