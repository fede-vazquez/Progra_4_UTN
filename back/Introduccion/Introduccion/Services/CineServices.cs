using Introduccion.Models.Cine;
using Introduccion.Models.Cine.DTO;

namespace Introduccion.Services
{
    public interface ICineServices
    {
        List<CinesDTO> GetAll();
        Cine GetOneById(int id);
    }
    public class CineServices : ICineServices
    {
        private List<Cine> cines = new() {
            new() { Id = 1, Name = "Cinemark", IsOpen = true },
            new() { Id = 2, Name = "Showcase", IsOpen = true },
            new() { Id = 3, Name = "Hoyts", IsOpen = true },
            new() { Id = 4, Name = "Cinepolis", IsOpen = false },
        };

        public List<CinesDTO> GetAll() {
            return cines.Select(c=> new CinesDTO { Id = c.Id, Name = c.Name }).ToList();
        }

        public Cine GetOneById(int id) {
        var cine = cines.FirstOrDefault(c => c.Id == id);
            if (cine != null)
            {
                return cine;
            }
            else
            {
                throw new Exception($"No se encontro el cine con el ID = {id}");
            }
        }
    }
}