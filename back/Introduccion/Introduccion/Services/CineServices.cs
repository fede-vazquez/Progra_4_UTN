using Introduccion.Models.Cine;
using Introduccion.Models.Cine.DTO;
using Introduccion.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Introduccion.Services
{
    public interface ICineServices
    {
        List<CinesDTO> GetAll();
        Cine GetOneById(int id);
        Cine CreateOne(CreateCineDTO createDTO);
        void DeleteOneById(int id);
    }
    public class CineServices : ICineServices
    {
        private static List<Cine> cines = new() {
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
                throw new HttpResponseError(HttpStatusCode.NotFound, $"No se encontro el cine con el ID = {id}");
            }
        }
        public Cine CreateOne(CreateCineDTO createDTO)
        {
            int lastId = cines.Last().Id;

            if(createDTO.Name.Trim().Length > 30)
            {
                throw new HttpResponseError(HttpStatusCode.BadRequest, $"El nombre del cine no puede tener más de 30 caracteres.");
            }

            Cine cine = new Cine { Id = lastId + 1, Description = createDTO.Description, IsOpen = createDTO.IsOpen, Name = createDTO.Name };

            cines.Add(cine);

            return cine;
        }
        public void DeleteOneById(int id)
        {
            var cine = cines.FirstOrDefault(c => c.Id == id);
            if (cine != null)
            {
                cines.Remove(cine);
            }
            else
            {
                throw new HttpResponseError(HttpStatusCode.NotFound, $"No se encontro el cine con el ID = {id}");
            }
        }
    }
}
