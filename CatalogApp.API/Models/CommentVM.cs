namespace CatalogApp.API.Models
{
    public class CommentVm
    {
        public int Id { get; set; }
        public int Grade { get; set; }
        public string Content { get; set; }

        public string UserId { get; set; }
        public UserVm User { get; set; }

        public int PhoneId { get; set; }
    }
}