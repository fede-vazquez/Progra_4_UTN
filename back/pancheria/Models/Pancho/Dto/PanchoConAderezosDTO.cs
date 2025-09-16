namespace pancheria.Models.Pancho.Dto
{
    public class PanchoConAderezosDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public double Precio { get; set; }
        public List<string> Aderezos { get; set; } = new List<string>();
    }
}
