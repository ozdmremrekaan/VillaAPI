using AutoMapper;
using MagicVilla_Web.Models.Dto.Villa;
using MagicVilla_Web.Models.Dto.VillaNumber;

namespace MagicVilla_Web
{
    public class MappingConfig:Profile
    {
        public MappingConfig()
        {
            CreateMap<VillaDto, VillaCreateDto>().ReverseMap();
            CreateMap<VillaDto, VillaUpdateDto>().ReverseMap();

            CreateMap<VillaNumberDto, VillaNumberCreateDto>().ReverseMap();
            CreateMap<VillaNumberDto, VillaNumberUpdateDto>().ReverseMap();
        }

    }
}
