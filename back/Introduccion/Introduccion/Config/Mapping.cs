using AutoMapper;
using Introduccion.Models.Cine;
using Introduccion.Models.Cine.DTO;

namespace Introduccion.Config
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<bool?, bool>().ConvertUsing((src, dest) => src ?? dest);
            CreateMap<string?, string>().ConvertUsing((src, dest) => src ?? dest);

            CreateMap<CreateCineDTO, Cine>().ReverseMap();
            CreateMap<UpdateCineDTO, Cine>().ForAllMembers(opts =>
            {
                opts.Condition((src, dest, srcMember) => srcMember != null);
            });
        }
    }
}
