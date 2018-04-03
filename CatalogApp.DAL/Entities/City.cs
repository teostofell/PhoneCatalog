using CatalogApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogApp.DAL.Entities
{
    public class City : IIdentifiable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        public ICollection<UserProfile> UserProfiles { get; set; }

        public City()
        {
            UserProfiles = new List<UserProfile>();
        }
    }
}
