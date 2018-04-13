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
        private IScreenResolutionService db;
        private IMapper mapper;

        public ScreenResolutionsController(IScreenResolutionService context)
        {
            db = context;
            mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<ScreenResolutionDTO, ScreenResolutionVM>();
            }).CreateMapper();

        }

        // GET: api/ScreenResolutions
        public IEnumerable<ScreenResolutionVM> Get()
        {
            var resolutions = db.GetScreenResolutions();
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
