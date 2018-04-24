using AutoMapper;
using CatalogApp.BLL.BusinessModel;
using CatalogApp.BLL.DTO;
using CatalogApp.BLL.Interfaces;
using CatalogApp.DAL.Entities;
using CatalogApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApp.BLL.Services
{
    public class OrderService : BaseService, IOrdersService
    {
        public OrderService(IUnitOfWork db, IMapper mapper) : base(db, mapper) {}

        public IEnumerable<OrderDto> GetOrders(string userId)
        {
            var orders = UnitOfWork.Orders.GetAll().Where(o => o.UserId == userId).Where(o => !o.IsActual)
                .Include(o => o.OrderItems).Include(o => o.OrderItems.Select(oi => oi.Phone)).ToList();

            return Mapper.Map<List<OrderDto>>(orders);
        }

        public IEnumerable<OrderItemDto> GetOrderItems(int orderId)
        {
            var items = UnitOfWork.Orders.Get(orderId).Include(o => o.OrderItems).FirstOrDefault()?.OrderItems.ToList();

            return Mapper.Map<List<OrderItemDto>>(items);
        }

        public async Task CreateOrder(string userId)
        {
            Order order = new Order() { IsActual=true, OrderDate=DateTime.Now, UserId=userId };

            try
            {
                UnitOfWork.Orders.Create(order);

                await UnitOfWork.SaveAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        public async Task<OrderDto> GetActualOrder(string userId)
        {
            var order = await UnitOfWork.Orders.GetAll().Where(o => o.UserId == userId)
                .Where(o => o.IsActual).Include(o => o.OrderItems).Include("OrderItems.Phone").FirstOrDefaultAsync();

            if(order == null)
            {
                order = new Order() { IsActual = true, OrderDate = DateTime.Now, UserId = userId };
                order = UnitOfWork.Orders.Create(order);

                await UnitOfWork.SaveAsync();
            }

            return Mapper.Map<OrderDto>(order);
        }

        public async Task CloseOrder(int orderId)
        {
            Order order;
            try
            {
                order = UnitOfWork.Orders.Get(orderId).FirstOrDefault();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }            

            order.IsActual = false;

            try
            {
                UnitOfWork.Orders.Update(order);

                await UnitOfWork.SaveAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }
    }
}
