using AutoMapper;
using AMS.Api.Models;
using AMS.Api.Dtos;
namespace AMS.Api.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Assets, AssetResponseDto>();
            CreateMap<AssetsCreateDto, Assets>();
            CreateMap<Categories, CategoriesResponseDto>();
            CreateMap<CategoriesCreateDto, Categories>();
            CreateMap<Location, LocationResponseDto>();
            CreateMap<LocationCreateDto, Location>();
        }
    }
}
