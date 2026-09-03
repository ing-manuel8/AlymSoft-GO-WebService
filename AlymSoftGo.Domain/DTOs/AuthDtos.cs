namespace AlymSoftGo.Domain.DTOs
{
    public class LoginRequestDto
    {
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }

    public class LoginResponseDto
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string Currency { get; set; } = "USD";
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
        public string CompanyName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string TimeZone { get; set; } = string.Empty;
        public string TimeZoneIANA { get; set; } = string.Empty;
    }

    public class RegisterResponseDto
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        public string Currency { get; set; } = "USD";
        public int? BranchId { get; set; }
        public string? BranchName { get; set; }
        public string? TimeZone { get; set; }
        public string? TimeZoneIANA { get; set; }
        public string Email { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public bool IsSuperAdmin { get; set; }
        public string? Permissions { get; set; }
    }

    public class RefreshTokenRequestDto
    {
        public string RefreshToken { get; set; } = string.Empty;
    }

    public class RefreshTokenResponseDto
    {
        public string AccessToken { get; set; } = string.Empty;
        public string RefreshToken { get; set; } = string.Empty;
    }
}
