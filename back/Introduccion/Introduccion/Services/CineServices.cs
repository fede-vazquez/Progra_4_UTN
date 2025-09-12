using Introduccion.Models;

namespace Introduccion.Services
{
    public class CineServices : IServices<Cine>
    {
        private List<Cine> cines = new() {
            new() { Id = 1, Name = "Cinemark", IsOpen = true },
            new() { Id = 2, Name = "Showcase", IsOpen = true },
            new() { Id = 3, Name = "Hoyts", IsOpen = true },
            new() { Id = 4, Name = "Cinepolis", IsOpen = false },
        };

        public List<Cine> GetAll() => cines;
        
    }
}
