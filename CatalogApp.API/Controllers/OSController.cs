using AutoMapper;
using CatalogApp.API.Models;
using CatalogApp.BLL.Interfaces;
using System.Collections.Generic;
using System.Web.Http;

namespace CatalogApp.API.Controllers
{
    public class OsController : ApiController
    {
        private readonly IOsService _osService;
        private readonly IMapper _mapper;

        public OsController(IOsService context, IMapper mapper)
        {
            _osService = context;
            _mapper = mapper;
        }

        // GET: api/OS
        public IEnumerable<OsViewModel> Get()
        {
            var os = _osService.GetOs();
            return _mapper.Map<List<OsViewModel>>(os);
        }
    }
}
