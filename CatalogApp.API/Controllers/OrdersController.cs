using AutoMapper;
using CatalogApp.API.Models;
using CatalogApp.BLL.DTO;
using CatalogApp.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CatalogApp.API.Controllers
{
    public class OrdersController : ApiController
    {
        private IOrdersService db;
        private IMapper mapper;

        public OrdersController(IOrdersService context)
        {
            db = context;
            mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<OrderDTO, OrderVM>().ReverseMap();
                cfg.CreateMap<OrderItemDTO, OrderItemVM>().ReverseMap();
            }).CreateMapper();

        }

        // GET: api/Orders
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Orders/5
        public HttpResponseMessage Get(string id)
        {
            var result = db.GetOrders(id);

            var response = Request.CreateResponse(HttpStatusCode.OK, result);

            return response;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetActualOrder(string userId)
        {
            var result = await db.GetActualOrder(userId);

            var response = Request.CreateResponse(HttpStatusCode.OK, mapper.Map<OrderVM>(result));

            return response;
        }

        // POST: api/Orders
        public async Task<HttpResponseMessage> Post([FromBody]string userId)
        {
            var result = await db.CreateOrder(userId);

            var response = Request.CreateResponse(HttpStatusCode.OK, result.Message);

            return response;
        }

        // PUT: api/Orders/5
        public void Put(int id, [FromBody]OrderVM value)
        {

        }

        // DELETE: api/Orders/5
        public void Delete(int id)
        {
        }
    }
}
