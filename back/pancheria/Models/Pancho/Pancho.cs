namespace pancheria.Models.Pancho
{
    public class Pancho
    {
        public int Id { get; set; }
        private string Nombre = string.Empty;
        public bool IsVegano { get; set; }
        public List<string> Aderezos { get; set; } = new List<string>();
        public double Precio { get; set; }

        public string GetNombre() => Nombre;
        public void SetNombre(string Nombre) {
            this.Nombre = Nombre;
        }
    }
}