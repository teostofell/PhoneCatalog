﻿namespace CatalogApp.BLL.DTO
{
    public class OrderItemDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public PhoneDto Phone { get; set; }
    }
}