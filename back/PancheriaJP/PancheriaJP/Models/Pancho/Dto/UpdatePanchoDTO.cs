using System.ComponentModel.DataAnnotations;

namespace PancheriaJP.Models.Pancho.Dto
{
    public class UpdatePanchoDTO
    {
        [MaxLength(30)]
        public string? Nombre { get; set; } = null!;

        public bool? IsVegano { get; set; }

        [Range(0.01, double.MaxValue)]
        public double? Precio { get; set; }

        public int? CategoriaId { get; set; }
    }
}
