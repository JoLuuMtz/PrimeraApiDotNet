using AutoMapper;
using Mi_primera_api_dotnet.DTOs;
using Mi_primera_api_dotnet.Model;

namespace Mi_primera_api_dotnet.AutoMappers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Mapeo Brand
            CreateMap<Brand, BrandDTO>();
            CreateMap<BrandDTO, Brand>();

            // Mapeo Beer    Insert

            CreateMap<CreatedBeerDTO, Beer>();
            CreateMap<Beer, BeersDTO>();


            // mapeo cuando los campos son diferentes
            //CreateMap<Beer, BeersDTO>()
            //    .ForMember(dest => dest.BrandName, opt => opt.MapFrom(src => src.Brand.Name))
            //    .ForMember(dest => dest.BrandId, opt => opt.MapFrom(src => src.Brand.Id));


        }
    }
}
