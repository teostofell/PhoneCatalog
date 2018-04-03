using CatalogApp.DAL.Contexts;
using CatalogApp.DAL.Entities;
using CatalogApp.DAL.Interfaces;
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
