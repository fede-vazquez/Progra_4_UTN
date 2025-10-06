using AutoMapper;
using Introduccion.Utils;
using Microsoft.EntityFrameworkCore;
using PancheriaJP.Config;
using PancheriaJP.Models.Pancho;
using PancheriaJP.Models.Pancho.Dto;
using PancheriaJP.Repositories;
using System.Net;

namespace PancheriaJP.Services
{
    public class PanchoServices
    {
        private readonly IMapper _mapper;
        private readonly IPanchoRepository _repo;
        public PanchoServices(IMapper mapper, IPanchoRepository repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        async private Task<PanchoDTO> GetOneByIdOrException(int id)
        {
            var panchito = await _repo.GetOne(p => p.Id == id);
            if (panchito == null)
            {
                throw new HttpResponseError(HttpStatusCode.NotFound, $"No hay panchito con id = {id}");
            }
            return _mapper.Map<PanchoDTO>(panchito);
        }

        async public Task<List<PanchosDTO>> GetAll()
        {
            var panchos = await _repo.GetAll();
            return _mapper.Map<List<PanchosDTO>>(panchos);
        }

        async public Task<PanchoDTO> GetOneById(int id) => await GetOneByIdOrException(id);

        async public Task<List<PanchoAderezoDTO>> GetAllByAderezo(string aderezo)
        {
            var panchos = await _repo.GetAll(p =>
                p.Aderezos.Contains(aderezo.ToLower())
            );

            return _mapper.Map<List<PanchoAderezoDTO>>(panchos);
        }

        async public Task<Pancho> CreateOne(CreatePanchoDTO createDTO)
        {
            if (createDTO.Aderezos != null && createDTO.Aderezos.Count > 0) {
                createDTO.Aderezos = createDTO.Aderezos.Select(x => x.ToLower()).ToList();
            }
            var pancho = _mapper.Map<Pancho>(createDTO);

            await _repo.CreateOne(pancho);

            return pancho;
        }

        async public Task<PanchoDTO> UpdateOneById(int id, UpdatePanchoDTO updateDTO)
        {
            var p = await GetOneByIdOrException(id);
            var panchito = _mapper.Map<Pancho>(p);

            var panchoMapped = _mapper.Map(updateDTO, panchito);

            await _repo.UpdateOne(panchoMapped);

            return _mapper.Map<PanchoDTO>(panchoMapped);
        }

        async public Task DeleteOneById(int id)
        {
            var p = await GetOneByIdOrException(id);
            var pancho = _mapper.Map<Pancho>(p);
            await _repo.DeleteOne(pancho);
        }
    }
}
