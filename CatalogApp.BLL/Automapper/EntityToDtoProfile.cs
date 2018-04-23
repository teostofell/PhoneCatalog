using AutoMapper;
using CatalogApp.BLL.DTO;
using CatalogApp.DAL.Entities;

namespace CatalogApp.BLL.Automapper
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<Brand, BrandDto>();
            CreateMap<City, CityDto>();
            CreateMap<Comment, CommentDto>().ReverseMap();
            CreateMap<Order, OrderDto>();
            CreateMap<OrderItem, OrderItemDto>();
            CreateMap<Os, Osdto>();
            CreateMap<Phone, PhoneDto>();
            CreateMap<Phone, Phone>();
            CreateMap<Photo, PhotoDto>();
            CreateMap<ScreenResolution, ScreenResolutionDto>();
            CreateMap<UserProfile, UserDto>();
        }
    }
}
