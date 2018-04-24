using System;
using AutoMapper;
using CatalogApp.BLL.BusinessModel;
using CatalogApp.BLL.DTO;
using CatalogApp.BLL.Interfaces;
using CatalogApp.DAL.Entities;
using CatalogApp.DAL.Interfaces;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CatalogApp.BLL.Services
{
    public class OrderItemService : BaseService, IOrderItemService
    {
        public OrderItemService(IUnitOfWork db, IMapper mapper) : base(db, mapper) {}


        public async Task AddToOrder(OrderItemDto item)
        {

            OrderItem orderItem = new OrderItem() { OrderId = item.OrderId, PhoneId = item.Phone.Id, Quantity = item.Quantity };

            Order order;
            try
            {
                order = await UnitOfWork.Orders.Get(item.OrderId).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }

            order.Total += item.Phone.Price * item.Quantity;

            try
            {
                UnitOfWork.Orders.Update(order);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }

            IQueryable<OrderItem> temp;
            try
            {
                temp = UnitOfWork.OrderItems.GetAll().Where(oi => (oi.OrderId == item.OrderId && oi.PhoneId == item.Phone.Id));
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }

            if (temp.FirstOrDefault() != null)
            {
                temp.Single().Quantity += item.Quantity;

                try
                {
                    await UnitOfWork.SaveAsync();
                }
                catch (Exception e)
                {
                    Debug.WriteLine(e);
                    throw;
                }

                return;
            }

            orderItem = UnitOfWork.OrderItems.Create(orderItem);

            try
            {
                await UnitOfWork.SaveAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        public async Task RemoveFromOrder(int orderItemId)
        {
            OrderItem item;
            try
            {
                item = await UnitOfWork.OrderItems.Get(orderItemId).Include(oi => oi.Phone).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }

            Order order;
            try
            {
                order = await UnitOfWork.Orders.Get(item.OrderId).FirstOrDefaultAsync();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }

            order.Total -= item.Phone.Price * item.Quantity;

            try
            {
                UnitOfWork.Orders.Update(order);

                UnitOfWork.OrderItems.Delete(orderItemId);

                await UnitOfWork.SaveAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
