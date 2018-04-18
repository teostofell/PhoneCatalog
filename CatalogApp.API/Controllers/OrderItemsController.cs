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
    public class OrderItemsController : ApiController
    {
        private IOrderItemService db;
        private IMapper mapper;

        public OrderItemsController(IOrderItemService context, IMapper mapper)
        {
            db = context;
            this.mapper = mapper;
            //mapper = new MapperConfiguration(cfg => {
            //    cfg.CreateMap<OrderItemVM, OrderItemDTO>().ReverseMap();
            //    cfg.CreateMap<PhoneDTO, PhoneSummaryVM>().ReverseMap();
            //}).CreateMapper();

        }

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
        public async Task<HttpResponseMessage> Post([FromBody]OrderItemVM item)
        {
            var result = await db.AddToOrder(mapper.Map<OrderItemDTO>(item));

            var response = Request.CreateResponse(HttpStatusCode.OK, result.Message);

            return response;
        }

        // PUT: api/OrderItems/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/OrderItems/5
        public async Task<HttpResponseMessage> Delete(int id)
        {
            var result = await db.RemoveFromOrder(id);

            var response = Request.CreateResponse(HttpStatusCode.OK, result.Message);

            return response;
        }
    }
}
