using CatalogApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogApp.DAL.Entities
{
    public class Phone : IIdentifiable
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Description { get; set; }
        public int Storage { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public float ScreenSize { get; set; }
        public int Battery { get; set; }
        public bool Fingerprint { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public int OSId { get; set; }
        public OS OS { get; set; }

        public int ScreenResolutionId { get; set; }
        public ScreenResolution ScreenResolution { get; set; }

        public ICollection<Photo> Photos { get; set; }

        public Phone()
        {
            Photos = new List<Photo>();
        }
    }
}
