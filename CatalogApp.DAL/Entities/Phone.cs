using CatalogApp.DAL.Interfaces;
using System.Collections.Generic;

namespace CatalogApp.DAL.Entities
{
    public class Phone : IIdentifiable
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Slug { get; set; }
        public string Photo { get; set; }
        public string Description { get; set; }
        public int Storage { get; set; }
        public decimal Price { get; set; }
        public int ReleaseYear { get; set; }
        public float ScreenSize { get; set; }
        public int Battery { get; set; }
        public bool Fingerprint { get; set; }
        public int Grade { get; set; }

        public int BrandId { get; set; }
        public Brand Brand { get; set; }

        public int OsId { get; set; }
        public Os Os { get; set; }

        public int ScreenResolutionId { get; set; }
        public ScreenResolution ScreenResolution { get; set; }

        public ICollection<Photo> Photos { get; set; }
        public ICollection<Comment> Comments { get; set; }

        public Phone()
        {
            Photos = new List<Photo>();
            Comments = new List<Comment>();
        }
    }
}
