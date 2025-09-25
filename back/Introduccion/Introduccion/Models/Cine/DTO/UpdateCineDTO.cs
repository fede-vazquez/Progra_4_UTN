using System.ComponentModel.DataAnnotations;

namespace Introduccion.Models.Cine.DTO
{
    public class UpdateCineDTO
    {
        [MaxLength(30, ErrorMessage = "El nombre no puede contener más de 30 caracteres")]
        public string? Name { get; set; } = null!;

        [MaxLength(255, ErrorMessage = "La Descripción no puede contener más de 255 caracteres")]
        public string? Description { get; set; }

        public bool? IsOpen { get; set; }
    }
}
