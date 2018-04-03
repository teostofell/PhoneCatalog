using CatalogApp.DAL.Interfaces;

namespace CatalogApp.DAL.Entities
{
    public class OrderItem : IIdentifiable
    {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public int PhoneId { get; set; }
        public Phone Phone { get; set; }

        public int OrderId { get; set; }
        public Order Order { get; set; }
    }
}