using AutoMapper;
using CatalogApp.API.Models;
using CatalogApp.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalogApp.API.Automapper
{
    public class DtoToVmProfile : Profile
    {
        public DtoToVmProfile()
        {
            CreateMap<BrandDTO, BrandVM>();
            CreateMap<CityDTO, CityVM>();
            CreateMap<CommentDTO, CommentVM>();
            CreateMap<OrderDTO, OrderVM>();
            CreateMap<OrderItemDTO, OrderItemVM>();
            CreateMap<OSDTO, OSVM>();
            CreateMap<PhoneDTO, PhoneSummaryVM>();
            CreateMap<PhotoDTO, PhotoVM>();
            CreateMap<ScreenResolutionDTO, ScreenResolutionVM>();
            CreateMap<UserDTO, UserVM>();
        }
    }
}