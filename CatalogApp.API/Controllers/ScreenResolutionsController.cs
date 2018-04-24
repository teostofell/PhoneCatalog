using AutoMapper;
using CatalogApp.API.Models;
using CatalogApp.BLL.Interfaces;
using System.Collections.Generic;
using System.Web.Http;

namespace CatalogApp.API.Controllers
{
    public class ScreenResolutionsController : ApiController
    {
        private readonly IScreenResolutionService _screenResolutionService;
        private readonly IMapper _mapper;

        public ScreenResolutionsController(IScreenResolutionService context, IMapper mapper)
        {
            _screenResolutionService = context;
            _mapper = mapper;
        }

        // GET: api/ScreenResolutions
        public IEnumerable<ScreenResolutionViewModel> Get()
        {
            var resolutions = _screenResolutionService.GetScreenResolutions();
            return _mapper.Map<List<ScreenResolutionViewModel>>(resolutions);
        }
    }
}
