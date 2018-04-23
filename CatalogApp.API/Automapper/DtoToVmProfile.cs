using AutoMapper;
using CatalogApp.API.Models;
using CatalogApp.BLL.DTO;

namespace CatalogApp.API.Automapper
{
    public class DtoToVmProfile : Profile
    {
        public DtoToVmProfile()
        {
            CreateMap<BrandDto, BrandVm>();
            CreateMap<CityDto, CityVm>();
            CreateMap<CommentDto, CommentVm>();
            CreateMap<OrderDto, OrderVm>();
            CreateMap<OrderItemDto, OrderItemVm>();
            CreateMap<Osdto, Osvm>();
            CreateMap<PhoneDto, PhoneSummaryVm>();
            CreateMap<PhotoDto, PhotoVm>();
            CreateMap<ScreenResolutionDto, ScreenResolutionVm>();
            CreateMap<UserDto, UserVm>();
        }
    }
}