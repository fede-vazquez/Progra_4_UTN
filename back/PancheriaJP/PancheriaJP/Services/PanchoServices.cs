using AutoMapper;
using Introduccion.Utils;
using PancheriaJP.Config;
using PancheriaJP.Models.Pancho;
using PancheriaJP.Models.Pancho.Dto;
using System.Net;

namespace PancheriaJP.Services
{
    public class PanchoServices
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;
        public PanchoServices(IMapper mapper, ApplicationDbContext db)
        {
            _mapper = mapper;
            _db = db;
        }

        //private List<Pancho> _db.Panchos. = new()
        //{
        //    new() { Id = 1, Nombre = "Normal", IsVegano = false, Precio = 12.50, Aderezos = new() { "Mayonesa", "Mostaza" } },
        //    new() { Id = 2, Nombre = "Super Pancho", IsVegano = false, Precio = 20, Aderezos = new() { "Mayonesa", "Mostaza", "Papitas" } },
        //};

        private Pancho GetOneByIdOrException(int id)
        {
            var panchito = _db.Panchos.FirstOrDefault(p => p.Id == id);

            if (panchito == null)
            {
                throw new HttpResponseError(HttpStatusCode.NotFound, $"No hay panchito con id = {id}");
            }
            return panchito;
        }

        public List<PanchosDTO> GetAll()
        {
            return _mapper.Map<List<PanchosDTO>>(_db.Panchos.ToList());
        }

        public Pancho GetOneById(int id) => GetOneByIdOrException(id);

        public List<PanchoAderezoDTO> GetAllByAderezo(string aderezo)
        {
            List<Pancho> panchos = _db.Panchos.ToList().FindAll(p => 
                p.Aderezos
                .Select(x => x.ToLower())
                .ToList()
                .Contains(aderezo.ToLower())
            );

            return _mapper.Map<List<PanchoAderezoDTO>>(panchos);
        }

        public Pancho CreateOne(CreatePanchoDTO createDTO)
        {
            var pancho = _mapper.Map<Pancho>(createDTO);

            _db.Panchos.Add(pancho);
            _db.SaveChanges();

            return pancho;
        }

        public Pancho UpdateOneById(int id, UpdatePanchoDTO updateDTO)
        {
            var pancho = GetOneByIdOrException(id);

            var panchoMapped = _mapper.Map(updateDTO, pancho);

            _db.Panchos.Update(panchoMapped);
            _db.SaveChanges();

            return panchoMapped;
        }

        public void DeleteOneById(int id)
        {
            var pancho = GetOneByIdOrException(id);
            _db.Panchos.Remove(pancho);
            _db.SaveChanges();
        }
    }
}
