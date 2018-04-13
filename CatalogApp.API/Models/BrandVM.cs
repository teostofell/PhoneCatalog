using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalogApp.API.Models
{
    public class BrandVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Slug { get; set; }
        public string Logo { get; set; }
    }
}