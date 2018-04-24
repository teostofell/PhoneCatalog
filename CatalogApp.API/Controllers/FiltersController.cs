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
        public FilterViewModel Get()
        {
            var filter = _filtersService.GetFilterValues();
            return _mapper.Map<FilterViewModel>(filter);
        }
    }
}
