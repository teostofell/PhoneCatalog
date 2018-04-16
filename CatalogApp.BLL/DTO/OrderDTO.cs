using CatalogApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogApp.BLL.DTO
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserId { get; set; }

        public decimal Total { get; set; }

        public UserProfile User { get; set; }

        public ICollection<OrderItemDTO> OrderItems { get; set; }
    }
}
