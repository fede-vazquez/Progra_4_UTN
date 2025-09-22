using AutoMapper;
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

        Cine UpdateOneById(int id, UpdateCineDTO updateDTO);
    }
    public class CineServices : ICineServices
    {
        private readonly IMapper _mapper;
        public CineServices(IMapper mapper)
        {
            _mapper = mapper;
        }

        private static List<Cine> cines = new() {
            new() { Id = 1, Name = "Cinemark", IsOpen = true },
            new() { Id = 2, Name = "Showcase", IsOpen = true },
            new() { Id = 3, Name = "Hoyts", IsOpen = true },
            new() { Id = 4, Name = "Cinepolis", IsOpen = false },
        };
        private Cine GetOneByIdOrException (int id)
        {
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

        public List<CinesDTO> GetAll() {
            return cines.Select(c=> new CinesDTO { Id = c.Id, Name = c.Name }).ToList();
        }

        public Cine GetOneById(int id) {
            var cine = GetOneByIdOrException(id);
            return cine;
        }
        public Cine CreateOne(CreateCineDTO createDTO)
        {
            int lastId = cines.Last().Id;

            Cine cine = _mapper.Map<Cine>(createDTO);

            cine.Id = lastId + 1;

            cines.Add(cine);

            return cine;
        }
        public void DeleteOneById(int id)
        {
            var cine = GetOneByIdOrException(id);
            cines.Remove(cine);
        }

        public Cine UpdateOneById(int id, UpdateCineDTO updateDTO)
        {
            var cine = GetOneByIdOrException(id);

            var cineMapped = _mapper.Map(updateDTO, cine);

            return cineMapped;
        }
    }
}
