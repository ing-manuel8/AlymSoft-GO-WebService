using System.ComponentModel.DataAnnotations;

namespace AlymSoftGo.Domain.DTOs.Branch
{
    public class SaveBranchRequestDto
    {
        public int? Id { get; set; }

        [Required(ErrorMessage = "El nombre de la sucursal es obligatorio")]
        [StringLength(150, ErrorMessage = "El nombre no puede exceder los 150 caracteres")]
        public string Name { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "La dirección no puede exceder los 500 caracteres")]
        public string? Address { get; set; }

        [StringLength(50, ErrorMessage = "El teléfono no puede exceder los 50 caracteres")]
        public string? Phone { get; set; }

        [StringLength(255, ErrorMessage = "El correo de contacto no puede exceder los 255 caracteres")]
        [EmailAddress(ErrorMessage = "El formato de correo no es válido")]
        public string? ContactEmail { get; set; }

        [StringLength(255, ErrorMessage = "El horario no puede exceder los 255 caracteres")]
        public string? OperatingHours { get; set; }

        public bool AllowsDelivery { get; set; } = true;

        public bool AllowsPickup { get; set; } = true;

        public string? TimeZone { get; set; }

        public string? TimeZoneIANA { get; set; }
    }
}
