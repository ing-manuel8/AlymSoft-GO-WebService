namespace AlymSoftGo.Domain.DTOs.Branch
{
    public class BranchDto
    {
        public int Id { get; set; }
        public int IdSucursal { set => Id = value; }

        public Guid? Uuid { get; set; }
        public Guid? VUUIDSucursal { set => Uuid = value; }

        public int CompanyId { get; set; }
        public int IdEmpresa { set => CompanyId = value; }

        public string Name { get; set; } = string.Empty;
        public string VNombre { set => Name = value; }

        public string? Address { get; set; }
        public string? VDireccion { set => Address = value; }

        public string? Phone { get; set; }
        public string? VTelefono { set => Phone = value; }

        public string? ContactEmail { get; set; }
        public string? VEmailContacto { set => ContactEmail = value; }

        public string? OperatingHours { get; set; }
        public string? VHorarioAtencion { set => OperatingHours = value; }

        public bool AllowsDelivery { get; set; }
        public bool BPermiteEntregaDomicilio { set => AllowsDelivery = value; }

        public bool AllowsPickup { get; set; }
        public bool BPermiteRecogerSucursal { set => AllowsPickup = value; }

        public string TimeZone { get; set; } = "Central Standard Time (Mexico)";
        public string? VTimeZone { set => TimeZone = value ?? "Central Standard Time (Mexico)"; }

        public string TimeZoneIANA { get; set; } = "America/Mexico_City";
        public string? VTimeZoneIANA { set => TimeZoneIANA = value ?? "America/Mexico_City"; }

        public string? Currency { get; set; }
        public string? VCurrency { set => Currency = value; }

        public string? Culture { get; set; }
        public string? VCulture { set => Culture = value; }

        public bool IsActive { get; set; }
        public bool BIsActive { set => IsActive = value; }
    }
}
