using CatalogApp.DAL.Contexts;
using CatalogApp.DAL.Entities;
using CatalogApp.DAL.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;

namespace CatalogApp.DAL.Repositories.MSSQL
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CatalogContext _db;

        private IRepository<Phone> _phoneRepository;
        private IRepository<Photo> _photoRepository;
        private IRepository<ScreenResolution> _screenResolutionRepository;
        private IRepository<Brand> _brandRepository;
        private IRepository<Os> _osRepository;
        private IRepository<Order> _orderRepository;
        private IRepository<City> _cityRepository;
        private IRepository<OrderItem> _orderItemRepository;
        private IRepository<Comment> _commentRepository;
        private ApplicationUserManager _userManager;
        private ApplicationRoleManager _roleManager;
        private IProfileManager _profileManager;

        public UnitOfWork(string connectionString)
        {
            _db = new CatalogContext(connectionString);
        }


        public IRepository<Phone> Phones => _phoneRepository ?? (_phoneRepository = new Repository<Phone>(_db));

        public IRepository<Brand> Brands => _brandRepository ?? (_brandRepository = new Repository<Brand>(_db));

        public IRepository<Os> OperatingSystems => _osRepository ?? (_osRepository = new Repository<Os>(_db));

        public IRepository<ScreenResolution> ScreenResolutions => _screenResolutionRepository ?? (_screenResolutionRepository = new Repository<ScreenResolution>(_db));

        public IRepository<Order> Orders => _orderRepository ?? (_orderRepository = new Repository<Order>(_db));

        public IRepository<City> Cities => _cityRepository ?? (_cityRepository = new Repository<City>(_db));

        public IRepository<Photo> Photos => _photoRepository ?? (_photoRepository = new Repository<Photo>(_db));

        public IRepository<OrderItem> OrderItems => _orderItemRepository ?? (_orderItemRepository = new Repository<OrderItem>(_db));

        public ApplicationUserManager UserManager => _userManager ?? (_userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(_db)));

        public IProfileManager ProfileManager => _profileManager ?? (_profileManager = new ProfileManager(_db));

        public ApplicationRoleManager RoleManager => _roleManager ?? (_roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(_db)));

        public IRepository<Comment> Comments => _commentRepository ?? (_commentRepository = new Repository<Comment>(_db));

        public void Dispose()
        {
            _db.Dispose();
        }

        public async Task SaveAsync()
        {
            await _db.SaveChangesAsync();
        }
    }
}
