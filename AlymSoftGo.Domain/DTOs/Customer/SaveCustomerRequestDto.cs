using System.ComponentModel.DataAnnotations;

namespace AlymSoftGo.Domain.DTOs.Customer
{
    public class SaveCustomerRequestDto
    {
        public int? CustomerId { get; set; }

        [Required(ErrorMessage = "El nombre del cliente es obligatorio")]
        [StringLength(255, ErrorMessage = "El nombre no puede exceder los 255 caracteres")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "El teléfono del cliente es obligatorio")]
        [StringLength(50, ErrorMessage = "El teléfono no puede exceder los 50 caracteres")]
        public string Phone { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "El formato de correo electrónico no es válido")]
        [StringLength(255, ErrorMessage = "El correo no puede exceder los 255 caracteres")]
        public string? Email { get; set; }

        [StringLength(500, ErrorMessage = "La dirección no puede exceder los 500 caracteres")]
        public string? DefaultAddress { get; set; }

        [StringLength(500, ErrorMessage = "Las notas no pueden exceder los 500 caracteres")]
        public string? Notes { get; set; }
    }
}
