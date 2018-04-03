using CatalogApp.DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogApp.DAL.Contexts
{
    public class CatalogContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<OS> OperatingSystems { get; set; }
        public DbSet<ScreenResolution> ScreenResolutions { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        /// <summary>
        /// Bind the initializer, that will initialize the database every time application is started
        /// </summary>
        static CatalogContext()
        {
            Database.SetInitializer<CatalogContext>(new DbInitializer());
        }       

        public CatalogContext(string connectionString)
            : base(connectionString)
        {

        }
    }
}
