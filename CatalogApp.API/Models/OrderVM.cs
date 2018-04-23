using System;
using System.Collections.Generic;

namespace CatalogApp.API.Models
{
    public class OrderVm
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }

        public ICollection<OrderItemVm> OrderItems { get; set; }
    }
}