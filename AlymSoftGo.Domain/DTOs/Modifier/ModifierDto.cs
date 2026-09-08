namespace AlymSoftGo.Domain.DTOs.Modifier
{
    public class ModifierDto
    {
        public int Id { get; set; }
        public int IdModificador { set => Id = value; }

        public int GroupId { get; set; }
        public int IdGrupoModificador { set => GroupId = value; }

        public int CompanyId { get; set; }
        public int IdEmpresa { set => CompanyId = value; }

        public string Name { get; set; } = string.Empty;
        public string VNombre { set => Name = value; }

        public decimal ExtraPrice { get; set; }
        public decimal DPrecioExtra { set => ExtraPrice = value; }

        public bool IsActive { get; set; }
        public bool BIsActive { set => IsActive = value; }
    }
}
