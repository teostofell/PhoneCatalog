using CatalogApp.DAL.Entities;
using System;
using System.Collections.Generic;

namespace CatalogApp.BLL.DTO
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public string UserId { get; set; }

        public decimal Total { get; set; }

        public UserProfile User { get; set; }

        public ICollection<OrderItemDto> OrderItems { get; set; }
    }
}
