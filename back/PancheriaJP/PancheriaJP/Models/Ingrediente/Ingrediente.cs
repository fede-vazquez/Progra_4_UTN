using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PancheriaJP.Models.Ingrediente
{
    public class Ingrediente
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nombre { get; set; } = null!;
    }

    public class PanchoIngrediente
    {
        public int PanchoId { get; set; }
        public int IngredienteId { get; set; }
    }
}
