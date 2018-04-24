using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using AutoMapper;
using CatalogApp.API.Models;
using CatalogApp.BLL.Interfaces;
using System.Web.Http;

namespace CatalogApp.API.Controllers
{
    public class FiltersController : ApiController
    {
        private readonly IFiltersService _filtersService;
        private readonly IMapper _mapper;

        public FiltersController(IFiltersService context, IMapper mapper)
        {
            _filtersService = context;
            _mapper = mapper;
        }

        // GET: api/Filters
        public HttpResponseMessage Get()
        {
            HttpResponseMessage response;
            try
            {
                var filter = _filtersService.GetFilterValues();
                var filterVm = _mapper.Map<FilterViewModel>(filter);
                response = Request.CreateResponse(HttpStatusCode.OK, filterVm);
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
