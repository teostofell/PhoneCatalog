using System;
using AutoMapper;
using CatalogApp.API.Models;
using CatalogApp.BLL.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
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
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response;
            try
            {
                var cities = _citiesService.GetCities();
                var citiesVm = _mapper.Map<List<CityViewModel>>(cities);
                response = Request.CreateResponse(HttpStatusCode.OK, citiesVm);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }

            return response;
        }
    }
}
