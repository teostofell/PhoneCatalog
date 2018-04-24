using System;
using System.Collections.Generic;

namespace CatalogApp.API.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public decimal Total { get; set; }

        public ICollection<OrderItemViewModel> OrderItems { get; set; }
    }
}