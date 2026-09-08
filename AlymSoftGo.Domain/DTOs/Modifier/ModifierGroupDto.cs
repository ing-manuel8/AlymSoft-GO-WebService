using System.Collections.Generic;

namespace AlymSoftGo.Domain.DTOs.Modifier
{
    public class ModifierGroupDto
    {
        public int Id { get; set; }
        public int IdGrupoModificador { set => Id = value; }

        public int CompanyId { get; set; }
        public int IdEmpresa { set => CompanyId = value; }

        public string Name { get; set; } = string.Empty;
        public string VNombre { set => Name = value; }

        public string? Description { get; set; }
        public string? VDescripcion { set => Description = value; }

        public bool IsRequired { get; set; }
        public bool BEsObligatorio { set => IsRequired = value; }

        public int MinSelect { get; set; }
        public int NMinimoSeleccion { set => MinSelect = value; }

        public int MaxSelect { get; set; }
        public int NMaximoSeleccion { set => MaxSelect = value; }

        public bool AllowsPartition { get; set; }
        public bool BPermiteParticion { set => AllowsPartition = value; }

        public int? OrderIndex { get; set; }
        public int? NOrden { set => OrderIndex = value; }

        public bool IsActive { get; set; }
        public bool BIsActive { set => IsActive = value; }

        public List<ModifierDto> Modifiers { get; set; } = new();
    }
}
