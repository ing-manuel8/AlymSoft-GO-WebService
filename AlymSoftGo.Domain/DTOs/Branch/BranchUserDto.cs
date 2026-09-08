namespace AlymSoftGo.Domain.DTOs.Branch
{
    public class BranchUserDto
    {
        public int Id { get; set; }
        public int IdUsuario { set => Id = value; }

        public int CompanyId { get; set; }
        public int IdEmpresa { set => CompanyId = value; }

        public int? BranchId { get; set; }
        public int? IdSucursal { set => BranchId = value; }

        public string FirstName { get; set; } = string.Empty;
        public string VNombre { set => FirstName = value; }

        public string? LastName { get; set; }
        public string? VApellido { set => LastName = value; }

        public string Email { get; set; } = string.Empty;
        public string VEmail { set => Email = value; }

        public string? Phone { get; set; }
        public string? VTelefono { set => Phone = value; }

        public int? RoleId { get; set; }
        public int? IdRol { set => RoleId = value; }

        public bool IsSuperAdmin { get; set; }
        public bool BIsSuperAdmin { set => IsSuperAdmin = value; }

        public bool IsActive { get; set; }
        public bool BIsActive { set => IsActive = value; }
    }
}
