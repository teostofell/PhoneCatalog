using CatalogApp.DAL.Interfaces;
using System.Collections.Generic;

namespace CatalogApp.DAL.Entities
{
    public class ScreenResolution : IIdentifiable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public ICollection<Phone> Phones { get; set; }

        public ScreenResolution()
        {
            Phones = new List<Phone>();
        }

    }
}