using CatalogApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogApp.BLL.BusinessModel
{
    public class FilterModel
    {
        // Filter fields
        public List<string> Brand { get; set; }
        public List<string> OS { get; set; }
        public Range<decimal> Price { get; set; }
        public Range<int> Storage { get; set; }

        public int Page { get; set; }
        public int ItemsOnPage { get; set; }
    }
}
