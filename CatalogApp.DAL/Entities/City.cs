using CatalogApp.DAL.Interfaces;
using System.Collections.Generic;

namespace CatalogApp.DAL.Entities
{
    public class City : IIdentifiable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        private ICollection<UserProfile> UserProfiles { get; set; }

        public City()
        {
            UserProfiles = new List<UserProfile>();
        }
    }
}
