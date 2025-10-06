using System.ComponentModel.DataAnnotations.Schema;

namespace PancheriaJP.Models.Pancho.Dto
{
    public class PanchoDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public bool IsVegano { get; set; }
        public double Precio { get; set; }
        public List<string> Aderezos { get; set; } = null!;
        public Categoria.Categoria Categoria { get; set; } = null!;
    }
}
