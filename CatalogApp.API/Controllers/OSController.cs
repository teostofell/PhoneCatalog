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
        public IEnumerable<Osvm> Get()
        {
            var os = _osService.GetOs();
            return _mapper.Map<List<Osvm>>(os);
        }

        // GET: api/OS/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/OS
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/OS/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/OS/5
        public void Delete(int id)
        {
        }
    }
}
