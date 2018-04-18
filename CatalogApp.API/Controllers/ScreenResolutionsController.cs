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
    public class ScreenResolutionsController : ApiController
    {
        private IScreenResolutionService screenResolutionService;
        private IMapper mapper;

        public ScreenResolutionsController(IScreenResolutionService context, IMapper mapper)
        {
            screenResolutionService = context;
            this.mapper = mapper;
        }

        // GET: api/ScreenResolutions
        public IEnumerable<ScreenResolutionVM> Get()
        {
            var resolutions = screenResolutionService.GetScreenResolutions();
            return mapper.Map<List<ScreenResolutionVM>>(resolutions);
        }

        // GET: api/ScreenResolutions/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ScreenResolutions
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ScreenResolutions/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ScreenResolutions/5
        public void Delete(int id)
        {
        }
    }
}
