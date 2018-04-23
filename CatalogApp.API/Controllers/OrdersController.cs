using AutoMapper;
using CatalogApp.API.Models;
using CatalogApp.BLL.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CatalogApp.API.Controllers
{
    public class OrdersController : ApiController
    {
        private readonly IOrdersService _ordersService;
        private readonly IMapper _mapper;

        public OrdersController(IOrdersService context, IMapper mapper)
        {
            _ordersService = context;
            _mapper = mapper;
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
            var result = _ordersService.GetOrders(id);

            var resultVm = _mapper.Map<List<OrderVm>>(result);

            var response = Request.CreateResponse(HttpStatusCode.OK, resultVm);

            return response;
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetActualOrder(string userId)
        {
            var result = await _ordersService.GetActualOrder(userId);

            var response = Request.CreateResponse(HttpStatusCode.OK, _mapper.Map<OrderVm>(result));

            return response;
        }

        // POST: api/Orders
        public async Task<HttpResponseMessage> Post([FromBody]string userId)
        {
            var result = await _ordersService.CreateOrder(userId);

            var response = Request.CreateResponse(HttpStatusCode.OK, result.Message);

            return response;
        }

        // PUT: api/Orders/5
        public void Put(int id, [FromBody]OrderVm value)
        {

        }

        // DELETE: api/Orders/5
        public void Delete(int id)
        {
            _ordersService.CloseOrder(id);
        }
    }
}
