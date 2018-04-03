using CatalogApp.DAL.Interfaces;
using System;

namespace CatalogApp.DAL.Entities
{
    public class UserProfile : IIdentifiable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreateTime { get; set; }
        public string Avatar { get; set; }

        public int CityId { get; set; }
        public City City { get; set; }

        // TODO: 1 to 1 relation
    }
}