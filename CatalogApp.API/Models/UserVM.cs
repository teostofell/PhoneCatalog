using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalogApp.API.Models
{
    public class UserVM
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Avatar { get; set; }
        public int CityId { get; set; }
        public string Role { get; set; }
        public DateTime CreateTime { get; set; }
        public bool IsAdmin { get; set; }
    }
}