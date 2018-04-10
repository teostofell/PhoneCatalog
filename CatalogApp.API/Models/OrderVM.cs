using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalogApp.API.Models
{
    public class OrderVM
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }

        public ICollection<OrderItemVM> OrderItems { get; set; }
    }
}