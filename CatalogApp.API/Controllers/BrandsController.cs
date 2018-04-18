using AutoMapper;
using CatalogApp.API.Models;
using CatalogApp.BLL.DTO;
using CatalogApp.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CatalogApp.API.Controllers
{
    public class BrandsController : ApiController
    {
        private IBrandService db;
        private IMapper mapper;

        public BrandsController(IBrandService context, IMapper mapper)
        {
            db = context;
            this.mapper = mapper;
        }

        // GET: api/Brands
        public IEnumerable<BrandVM> Get()
        {
            var brands = db.GetBrands();
            return mapper.Map<List<BrandVM>>(brands);
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
