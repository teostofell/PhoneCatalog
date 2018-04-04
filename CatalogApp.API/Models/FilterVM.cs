using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalogApp.API.Models
{
    public class FilterVM
    {
        public Dictionary<string, bool> Brand { get; set; }
        public Dictionary<string, bool> OS { get; set; }
        public Dictionary<string, int> Storage { get; set; }
        public Dictionary<string, decimal> Price { get; set; }

        public int Page { get; set; }
        public int ItemsOnPage { get; set; }
    }
}