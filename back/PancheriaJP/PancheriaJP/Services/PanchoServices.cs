﻿using AutoMapper;
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
        private readonly CategoriaServices _catServices;
        private readonly IngredienteServices _ingServices;
        public PanchoServices(IMapper mapper, IPanchoRepository repo, CategoriaServices catServices, IngredienteServices ingServices)
        {
            _mapper = mapper;
            _repo = repo;
            _catServices = catServices;
            _ingServices = ingServices;
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

        async public Task<PanchoDTO> CreateOne(CreatePanchoDTO createDTO)
        {
            var pancho = _mapper.Map<Pancho>(createDTO);

            var ings = await _ingServices.GetManyByIds(createDTO.IngredientesIds);
            pancho.Ingredientes = ings;

            await _repo.CreateOne(pancho);

            var cat = await _catServices.GetOneById(pancho.CategoriaId);
            pancho.Categoria = cat;

            return _mapper.Map<PanchoDTO>(pancho);
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
