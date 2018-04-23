using CatalogApp.DAL.Interfaces;

namespace CatalogApp.DAL.Entities
{
    public class Photo : IIdentifiable
    {
        public int Id { get; set; }
        public string Path { get; set; }

        public int PhoneId { get; set; }
        public Phone Phone { get; set; }
    }
}
