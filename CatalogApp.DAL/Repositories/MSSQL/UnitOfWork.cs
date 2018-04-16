using CatalogApp.DAL.Contexts;
using CatalogApp.DAL.Entities;
using CatalogApp.DAL.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogApp.DAL.Repositories.MSSQL
{
    public class UnitOfWork : IUnitOfWork
    {
        private CatalogContext db;

        private IRepository<Phone> phoneRepository;
        private IRepository<Photo> photoRepository;
        private IRepository<ScreenResolution> screenResolutionRepository;
        private IRepository<Brand> brandRepository;
        private IRepository<OS> osRepository;
        private IRepository<Order> orderRepository;
        private IRepository<City> cityRepository;
        private IRepository<OrderItem> orderItemRepository;
        private IRepository<Comment> commentRepository;
        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;
        private IProfileManager profileManager;

        public UnitOfWork(string connectionString)
        {
            db = new CatalogContext(connectionString);
        }


        public IRepository<Phone> Phones => phoneRepository ?? (phoneRepository = new Repository<Phone>(db));

        public IRepository<Brand> Brands => brandRepository ?? (brandRepository = new Repository<Brand>(db));

        public IRepository<OS> OperatingSystems => osRepository ?? (osRepository = new Repository<OS>(db));

        public IRepository<ScreenResolution> ScreenResolutions => screenResolutionRepository ?? (screenResolutionRepository = new Repository<ScreenResolution>(db));

        public IRepository<Order> Orders => orderRepository ?? (orderRepository = new Repository<Order>(db));

        public IRepository<City> Cities => cityRepository ?? (cityRepository = new Repository<City>(db));

        public IRepository<Photo> Photos => photoRepository ?? (photoRepository = new Repository<Photo>(db));

        public IRepository<OrderItem> OrderItems => orderItemRepository ?? (orderItemRepository = new Repository<OrderItem>(db));

        public ApplicationUserManager UserManager => userManager ?? (userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db)));

        public IProfileManager ProfileManager => profileManager ?? (profileManager = new ProfileManager(db));

        public ApplicationRoleManager RoleManager => roleManager ?? (roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db)));

        public IRepository<Comment> Comments => commentRepository ?? (commentRepository = new Repository<Comment>(db));

        public void Dispose()
        {
            db.Dispose();
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }
    }
}
