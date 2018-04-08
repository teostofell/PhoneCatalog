using AutoMapper;
using CatalogApp.BLL.DTO;
using CatalogApp.BLL.Interfaces;
using CatalogApp.DAL.Entities;
using CatalogApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogApp.BLL.Services
{
    public class OrderService : IOrdersService
    {
        private IUnitOfWork Db { get; set; }
        private IMapper mapper;

        public OrderService(IUnitOfWork db)
        {
            Db = db;

            mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Order, OrderDTO>();
            }).CreateMapper();
        }

        public IEnumerable<OrderDTO> GetOrders(int userId)
        {
            var orders = Db.Orders.GetAll().Where(o => o.UserId == userId)
                .Include(o => o.OrderItems);

            

            return mapper.Map<List<OrderDTO>>(orders);
        }
    }
}
