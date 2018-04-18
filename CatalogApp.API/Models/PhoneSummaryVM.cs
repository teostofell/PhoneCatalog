using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalogApp.API.Models
{
    public class PhoneSummaryVM
    {
        public int Id { get; set; }
        public string Model { get; set; }
        public string Slug { get; set; }
        public string Description { get; set; }
        public string Photo { get; set; }
        public int Storage { get; set; }
        public decimal Price { get; set; }
        public int ReleaseYear { get; set; }
        public float ScreenSize { get; set; }
        public int Battery { get; set; }
        public bool Fingerprint { get; set; }
        public int Grade { get; set; }
    }
}