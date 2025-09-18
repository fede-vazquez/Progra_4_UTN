namespace pancheria.Models.Pancho
{
    public class Pancho
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = string.Empty;
        public bool IsVegano { get; set; }
        public List<string> Aderezos { get; set; } = new List<string>();
        public double Precio { get; set; }
    }
}