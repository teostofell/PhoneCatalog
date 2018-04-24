using AutoMapper;
using CatalogApp.API.Models;
using CatalogApp.BLL.Interfaces;
using System.Collections.Generic;
using System.Web.Http;

namespace CatalogApp.API.Controllers
{
    public class BrandsController : ApiController
    {
        private readonly IBrandService _brandService;
        private readonly IMapper _mapper;

        public BrandsController(IBrandService context, IMapper mapper)
        {
            _brandService = context;
            _mapper = mapper;
        }

        // GET: api/Brands
        public IEnumerable<BrandViewModel> Get()
        {
            var brands = _brandService.GetBrands();
            return _mapper.Map<List<BrandViewModel>>(brands);
        }
    }
}
