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
        public IEnumerable<ScreenResolutionVm> Get()
        {
            var resolutions = _screenResolutionService.GetScreenResolutions();
            return _mapper.Map<List<ScreenResolutionVm>>(resolutions);
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
