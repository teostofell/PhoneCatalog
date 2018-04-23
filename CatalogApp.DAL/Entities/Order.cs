using CatalogApp.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace CatalogApp.DAL.Entities
{
    public class Order : IIdentifiable
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        public decimal Total { get; set; }

        public string UserId { get; set; }
        public UserProfile User { get; set; }

        public bool IsActual { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }

        public Order()
        {
            OrderItems = new List<OrderItem>();
        }
    }
}
