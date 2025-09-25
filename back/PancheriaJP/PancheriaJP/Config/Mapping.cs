using AutoMapper;
using PancheriaJP.Models.Pancho;
using PancheriaJP.Models.Pancho.Dto;

namespace Introduccion.Config
{
    public class Mapping : Profile
    {
        public Mapping() {

            CreateMap<bool?, bool>().ConvertUsing((src, dest) => src ?? dest);
            CreateMap<string?, string>().ConvertUsing((src, dest) => src ?? dest);
            CreateMap<List<string>?, List<string>>().ConvertUsing((src, dest) => src ?? dest);
            CreateMap<double?, double>().ConvertUsing((src, dest) => src ?? dest);

            CreateMap<Pancho, PanchosDTO>();
            CreateMap<Pancho, PanchoAderezoDTO>();

            CreateMap<CreatePanchoDTO, Pancho>().ReverseMap();

            CreateMap<UpdatePanchoDTO, Pancho>().ForAllMembers(opts =>
            {
                opts.Condition((_, _, srcMember) => srcMember != null);
            });
        }
    }
}
