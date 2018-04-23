using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogApp.DAL.Entities
{
    public class UserProfile
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreateTime { get; set; }
        public string Avatar { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public ICollection<Order> Orders { get; set; }
        public ICollection<Comment> Comments { get; set; }

        public UserProfile()
        {
            Orders = new List<Order>();
            Comments = new List<Comment>();
        }

    }
}