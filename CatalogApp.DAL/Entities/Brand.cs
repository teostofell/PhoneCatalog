using CatalogApp.DAL.Interfaces;
using System.Collections.Generic;

namespace CatalogApp.DAL.Entities
{
    public class Brand : IIdentifiable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Logo { get; set; }

        public ICollection<Phone> Phones { get; set; }

        public Brand()
        {
            Phones = new List<Phone>();
        }
    }
}