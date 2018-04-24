using AutoMapper;
using CatalogApp.API.Models;
using CatalogApp.BLL.DTO;

namespace CatalogApp.API.Automapper
{
    public class DtoToVmProfile : Profile
    {
        public DtoToVmProfile()
        {
            CreateMap<BrandDto, BrandViewModel>();
            CreateMap<CityDto, CityViewModel>();
            CreateMap<CommentDto, CommentViewModel>();
            CreateMap<OrderDto, OrderViewModel>();
            CreateMap<OrderItemDto, OrderItemViewModel>();
            CreateMap<OsDto, OsViewModel>();
            CreateMap<PhoneDto, PhoneSummaryViewModel>();
            CreateMap<PhotoDto, PhotoViewModel>();
            CreateMap<ScreenResolutionDto, ScreenResolutionViewModel>();
            CreateMap<UserDto, UserViewModel>();
        }
    }
}