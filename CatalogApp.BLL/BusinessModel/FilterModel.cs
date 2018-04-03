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
        public IEnumerable<Phone> Phones { get; set; }

        // Filter fields
        public Dictionary<string, bool> Brand { get; set; }
        public Dictionary<string, int> Storage { get; set; }
        public Dictionary<string, decimal> Price { get; set; }
        public Dictionary<string, bool> OS { get; set; }

        private FilterModel brandFilter()
        {            
            List<string> selectedValues = Brand.Where(kv => kv.Value).Select(kv => kv.Key).ToList();

            this.Phones = Phones.Where(p => selectedValues.Contains(p.Brand.Name));
           
            return this;
        }

        public IEnumerable<Phone> Filter(IEnumerable<Phone> phones)
        {
            brandFilter();
            return Phones;
        }

    }
}
