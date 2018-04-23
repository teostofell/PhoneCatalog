using CatalogApp.DAL.Interfaces;
using System.Collections.Generic;

namespace CatalogApp.DAL.Entities
{
    public class Os : IIdentifiable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }

        public ICollection<Phone> Phones { get; set; }

        public Os()
        {
            Phones = new List<Phone>();
        }
    }
}