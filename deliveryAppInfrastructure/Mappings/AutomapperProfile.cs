using AppCore.DTOs;
using AutoMapper;
using deliveryAppCore.DTOs;
using deliveryAppCore.Entities;

namespace deliveryAppInfrastructure.Mappings
{
    class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<User, LoginDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Po, PoDto>().ReverseMap();
            
        }
    }
}
