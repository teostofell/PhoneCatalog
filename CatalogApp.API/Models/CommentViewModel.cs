namespace CatalogApp.API.Models
{
    public class CommentViewModel
    {
        public int Id { get; set; }
        public int Grade { get; set; }
        public string Content { get; set; }

        public string UserId { get; set; }
        public UserViewModel User { get; set; }

        public int PhoneId { get; set; }
    }
}