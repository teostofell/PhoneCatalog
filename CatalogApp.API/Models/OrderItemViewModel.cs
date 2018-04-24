namespace CatalogApp.API.Models
{
    public class OrderItemViewModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public PhoneSummaryViewModel Phone { get; set; }
    }
}