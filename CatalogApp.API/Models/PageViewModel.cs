using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CatalogApp.API.Models
{
    public class PageViewModel
    {
        public int TotalPages { get; set; }
        public int TotalItems { get; set; }
        public IEnumerable<PhoneSummaryViewModel> Items { get; set; }
    }
}