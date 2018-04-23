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
        public IEnumerable<BrandVm> Get()
        {
            var brands = _brandService.GetBrands();
            return _mapper.Map<List<BrandVm>>(brands);
        }

        // GET: api/Brands/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Brands
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Brands/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Brands/5
        public void Delete(int id)
        {
        }
    }
}
