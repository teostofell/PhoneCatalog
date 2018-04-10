namespace CatalogApp.API.Models
{
    public class OrderItemVM
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public PhoneSummaryVM Phone { get; set; }
    }
}