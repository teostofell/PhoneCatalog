namespace CatalogApp.API.Models
{
    public class OrderItemVm
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int Quantity { get; set; }
        public PhoneSummaryVm Phone { get; set; }
    }
}