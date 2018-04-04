using AutoMapper;
using CatalogApp.API.Models;
using CatalogApp.BLL.BusinessModel;
using CatalogApp.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CatalogApp.API.Controllers
{
    public class FiltersController : ApiController
    {
        private IFiltersService db;
        private IMapper mapper;

        public FiltersController(IFiltersService context)
        {
            db = context;
            mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<FilterModel, FilterVM>()
                    .ForMember(dest => dest.Brand, opts => opts.MapFrom(src => src.Brand.ToDictionary(c => c, c => false)))
                    .ForMember(dest => dest.OS, opts => opts.MapFrom(src => src.OS.ToDictionary(g => g.ToString(), g => false)));
            }).CreateMapper();

        }

        // GET: api/Filters
        public FilterVM Get()
        {
            var filter = db.GetFilterValues();
            return mapper.Map<FilterVM>(filter);
        }

        // GET: api/Filters/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Filters
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Filters/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Filters/5
        public void Delete(int id)
        {
        }
    }
}
