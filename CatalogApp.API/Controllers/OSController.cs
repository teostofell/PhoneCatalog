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
    public class OSController : ApiController
    {
        private IOSService db;
        private IMapper mapper;

        public OSController(IOSService context, IMapper mapper)
        {
            db = context;
            this.mapper = mapper;
        }

        // GET: api/OS
        public IEnumerable<OSVM> Get()
        {
            var os = db.GetOS();
            return mapper.Map<List<OSVM>>(os);
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
