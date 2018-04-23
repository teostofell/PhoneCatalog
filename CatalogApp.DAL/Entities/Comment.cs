using CatalogApp.DAL.Interfaces;

namespace CatalogApp.DAL.Entities
{
    public class Comment : IIdentifiable
    {
        public int Id { get; set; }
        public int Grade { get; set; }
        public string Content { get; set; }

        public string UserId { get; set; }
        public UserProfile User { get; set; }

        public int PhoneId { get; set; }
        public Phone Phone { get; set; }
    }
}
