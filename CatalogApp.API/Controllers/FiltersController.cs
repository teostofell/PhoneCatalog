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
        public FilterVm Get()
        {
            var filter = _filtersService.GetFilterValues();
            return _mapper.Map<FilterVm>(filter);
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
