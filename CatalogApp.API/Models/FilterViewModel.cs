using CatalogApp.BLL.BusinessModel;
using System.Collections.Generic;

namespace CatalogApp.API.Models
{
    public class FilterViewModel
    {
        public List<string> Brand { get; set; }
        public List<string> Os { get; set; }
        public Range<decimal> Price { get; set; }
        public Range<int> Storage { get; set; }

        public int Page { get; set; }
        public int ItemsOnPage { get; set; }
    }
}