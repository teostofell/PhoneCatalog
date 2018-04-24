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
        public IEnumerable<CityViewModel> Get()
        {
            var cities = _citiesService.GetCities();
            return _mapper.Map<List<CityViewModel>>(cities);
        }
    }
}
