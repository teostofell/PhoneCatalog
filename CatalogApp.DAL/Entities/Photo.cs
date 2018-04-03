using CatalogApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogApp.DAL.Entities
{
    public class Photo : IIdentifiable
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string Color { get; set; }

        public int PhoneId { get; set; }
        public Phone Phone { get; set; }
    }
}
