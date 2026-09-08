namespace AlymSoftGo.Domain.DTOs
{
    public class BranchDto
    {
        public int Id { get; set; }
        public int IdSucursal { set => Id = value; }

        public string Name { get; set; } = string.Empty;
        public string VNombre { set => Name = value; }

        public string? TimeZone { get; set; }
        public string? VTimeZone { set => TimeZone = value; }

        public string? TimeZoneIANA { get; set; }
        public string? VTimeZoneIANA { set => TimeZoneIANA = value; }
    }
}
