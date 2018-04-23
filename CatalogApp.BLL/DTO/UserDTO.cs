using System;

namespace CatalogApp.BLL.DTO
{
    public class UserDto
    {
        public string Id { get; set; }
        public int CityId { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public string Role { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
