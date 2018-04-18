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
    public class CitiesController : ApiController
    {
        private ICitiesService db;
        private IMapper mapper;

        public CitiesController(ICitiesService context, IMapper mapper)
        {
            db = context;
            this.mapper = mapper;
        }


        // GET: api/Cities
        public IEnumerable<CityVM> Get()
        {
            var cities = db.GetCities();
            return mapper.Map<List<CityVM>>(cities);
        }

        // GET: api/Cities/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Cities
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Cities/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Cities/5
        public void Delete(int id)
        {
        }
    }
}
