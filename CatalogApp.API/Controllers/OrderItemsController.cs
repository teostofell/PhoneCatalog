using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CatalogApp.API.Controllers
{
    public class OrderItemsController : ApiController
    {
        // GET: api/OrderItems
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/OrderItems/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/OrderItems
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/OrderItems/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/OrderItems/5
        public void Delete(int id)
        {
        }
    }
}
