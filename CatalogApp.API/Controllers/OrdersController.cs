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
        private IOrdersService ordersService;
        private IMapper mapper;

        public OrdersController(IOrdersService context, IMapper mapper)
        {
            ordersService = context;
            this.mapper = mapper;
        }

        // GET: api/Orders
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Orders/5
        public HttpResponseMessage Get(string id)
        {
            var result = ordersService.GetOrders(id);

            var resultVm = mapper.Map<List<OrderVM>>(result);

            var response = Request.CreateResponse(HttpStatusCode.OK, resultVm);

            return response;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetActualOrder(string userId)
        {
            var result = await ordersService.GetActualOrder(userId);

            var response = Request.CreateResponse(HttpStatusCode.OK, mapper.Map<OrderVM>(result));

            return response;
        }

        // POST: api/Orders
        public async Task<HttpResponseMessage> Post([FromBody]string userId)
        {
            var result = await ordersService.CreateOrder(userId);

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
            ordersService.CloseOrder(id);
        }
    }
}
