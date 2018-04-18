using AutoMapper;
using CatalogApp.BLL.DTO;
using CatalogApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogApp.BLL.Automapper
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<Brand, BrandDTO>();
            CreateMap<City, CityDTO>();
            CreateMap<Comment, CommentDTO>().ReverseMap();
            CreateMap<Order, OrderDTO>();
            CreateMap<OrderItem, OrderItemDTO>();
            CreateMap<OS, OSDTO>();
            CreateMap<Phone, PhoneDTO>();
            CreateMap<Phone, Phone>();
            CreateMap<Photo, PhotoDTO>();
            CreateMap<ScreenResolution, ScreenResolutionDTO>();
            CreateMap<UserProfile, UserDTO>();
        }
    }
}
