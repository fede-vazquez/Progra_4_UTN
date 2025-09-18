using pancheria.Models.Pancho;
using pancheria.Models.Pancho.Dto;

namespace pancheria.Services
{
    public interface IPanchoServices
    {
        List<PanchosDTO> GetPanchos();
        Pancho GetPanchoById(int id);
        List<PanchoConAderezosDTO> GetPanchosPorAderezo(string aderezo); 
    }
    public class PanchoServices : IPanchoServices
    {
        private List<Pancho> _panchos = new() {
            new() { Id = 1, Nombre="Pancho 1", IsVegano = false, Aderezos = {"Mayonesa", "Mostaza" } },
            new() { Id = 2, Nombre="Pancho 2", IsVegano = false, Aderezos = {"Mostaza"} },
            new() { Id = 3, Nombre="Pancho 3", IsVegano = false, Aderezos = {} },
            new() { Id = 4, Nombre="Pancho 4", IsVegano = true, Aderezos = {"Mayonesa"} }
            };

        public List<PanchosDTO> GetPanchos()
        {
            return _panchos.Select(p => new PanchosDTO { Id = p.Id, Nombre = p.Nombre, Precio = p.Precio }).ToList();
        }

        public Pancho GetPanchoById(int id)
        {
            var pancho = _panchos.FirstOrDefault(p => p.Id == id);
            if (pancho != null)
            {
                return pancho;
            }
            else
            {
                throw new Exception($"No se encontro el pancho con el ID = {id}");
            }
        }
        public List<PanchoConAderezosDTO> GetPanchosPorAderezo(string aderezo)
        {
            List<Pancho> panchosConAderezo = _panchos.FindAll(p => p.Aderezos.Contains(aderezo));
            if (panchosConAderezo.Count == 0)
            {
                return panchosConAderezo.Select(p => new PanchoConAderezosDTO { Id = p.Id, Nombre = p.Nombre, Precio = p.Precio, Aderezos = p.Aderezos }).ToList();
            }
            else
            {
                throw new Exception($"No se encontraron panchos con el aderezo {aderezo}");
            }
        }
    }
}