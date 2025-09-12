using Introduccion.Models;

namespace Introduccion.Services
{
    public class HeladoServices : IServices<Helado>
    {
        private List<Helado> helados = new() {
            new() { Id = 1, Nombre = "Vainilla", Precio = 1500 },
            new() { Id = 2, Nombre = "Chocolate", Precio = 2000, HasAzucar = true },
            new() { Id = 3, Nombre = "DDL Con Brownie", Precio = 2500, HasAzucar = true }
        };

        public List<Helado> GetAll() => helados;
    }
}
