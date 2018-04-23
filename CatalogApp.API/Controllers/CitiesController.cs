using AutoMapper;
using CatalogApp.API.Models;
using CatalogApp.BLL.Interfaces;
using System.Collections.Generic;
using System.Web.Http;

namespace CatalogApp.API.Controllers
{
    public class CitiesController : ApiController
    {
        private readonly ICitiesService _citiesService;
        private readonly IMapper _mapper;

        public CitiesController(ICitiesService context, IMapper mapper)
        {
            _citiesService = context;
            _mapper = mapper;
        }


        // GET: api/Cities
        public IEnumerable<CityVm> Get()
        {
            var cities = _citiesService.GetCities();
            return _mapper.Map<List<CityVm>>(cities);
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
