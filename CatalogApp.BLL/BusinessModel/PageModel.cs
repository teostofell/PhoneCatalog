using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogApp.BLL.BusinessModel
{
    public class PageModel
    {
        public int Items { get; set; }
        public int Current { get; set; }
        public int Total { get; set; }
    }
}
