using AutoMapper;
using CatalogApp.BLL.BusinessModel;
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
    public class OrderService : BaseService, IOrdersService
    {
        public OrderService(IUnitOfWork db, IMapper mapper) : base(db, mapper) {}

        public IEnumerable<OrderDTO> GetOrders(string userId)
        {
            var orders = unitOfWork.Orders.GetAll().Where(o => o.UserId == userId).Where(o => !o.IsActual)
                .Include(o => o.OrderItems).Include(o => o.OrderItems.Select(oi => oi.Phone)).ToList();

            return mapper.Map<List<OrderDTO>>(orders);
        }

        public IEnumerable<OrderItemDTO> GetOrderItems(int orderId)
        {
            var items = unitOfWork.Orders.Get(orderId).Include(o => o.OrderItems).FirstOrDefault().OrderItems.ToList();

            return mapper.Map<List<OrderItemDTO>>(items);
        }

        public async Task<OperationDetails> CreateOrder(string userId)
        {
            Order order = new Order() { IsActual=true, OrderDate=DateTime.Now, UserId=userId };

            unitOfWork.Orders.Create(order);     

            await unitOfWork.SaveAsync();
            return new OperationDetails(true, "Order has been created");
        }

        public async Task<OrderDTO> GetActualOrder(string userId)
        {
            var order = await unitOfWork.Orders.GetAll().Where(o => o.UserId == userId)
                .Where(o => o.IsActual).Include(o => o.OrderItems).Include("OrderItems.Phone").FirstOrDefaultAsync();

            if(order == null)
            {
                order = new Order() { IsActual = true, OrderDate = DateTime.Now, UserId = userId };
                order = unitOfWork.Orders.Create(order);

                await unitOfWork.SaveAsync();
            }

            return mapper.Map<OrderDTO>(order);
        }

        public async Task<OperationDetails> CloseOrder(int orderId)
        {
            var order = unitOfWork.Orders.Get(orderId).FirstOrDefault();

            order.IsActual = false;

            unitOfWork.Orders.Update(order);

            await unitOfWork.SaveAsync();

            return new OperationDetails(true, "Order has been closed");
        }
    }
}
