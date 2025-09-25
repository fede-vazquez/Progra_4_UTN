using AutoMapper;
using Introduccion.Models.Cine;
using Introduccion.Models.Cine.DTO;

namespace Introduccion.Config
{
    public class Mapping : Profile
    {
        public Mapping() {

            // default bool (false)
            CreateMap<bool?, bool>().ConvertUsing((src, dest) => src ?? dest);

            // default string (null OR "")
            CreateMap<string?, string>().ConvertUsing((src, dest) => src ?? dest);

            // Mapeo bidireccional
            CreateMap<CreateCineDTO, Cine>().ReverseMap();

            // Mapeo unidireccional
            CreateMap<Cine, CinesDTO>();

            // Mapear SOLO si la propiedad es diferente de null
            CreateMap<UpdateCineDTO, Cine>().ForAllMembers(opts =>
            {
                opts.Condition((_, _, srcMember) => srcMember != null);
            });
        }
    }
}
