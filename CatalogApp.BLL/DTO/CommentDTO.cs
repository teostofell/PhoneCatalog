namespace CatalogApp.BLL.DTO
{
    public class CommentDto
    {
        public int Id { get; set; }
        public int Grade { get; set; }
        public string Content { get; set; }

        public string UserId { get; set; }
        public UserDto User { get; set; }

        public int PhoneId { get; set; }
    }
}
