using AutoMapper;
using CatalogApp.API.Automapper;
using CatalogApp.BLL.Interfaces;
using CatalogApp.BLL.Services;
using CatalogApp.BLL.Utils;
using Ninject;
using Ninject.Web.Common.WebHost;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CatalogApp.API
{
    public class WebApiApplication : NinjectHttpApplication
    {
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

        }

        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            RegisterServices(kernel);
            return kernel;
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IPhonesService>().To<PhonesService>().InScope(cfg => HttpContext.Current);
            kernel.Bind<IFiltersService>().To<FiltersService>().InScope(cfg => HttpContext.Current);
            kernel.Bind<IUserService>().To<UserService>().InScope(cfg => HttpContext.Current);
            kernel.Bind<IOrdersService>().To<OrderService>().InScope(cfg => HttpContext.Current);
            kernel.Bind<IOrderItemService>().To<OrderItemService>().InScope(cfg => HttpContext.Current);
            kernel.Bind<ICitiesService>().To<CitiesService>().InScope(cfg => HttpContext.Current);
            kernel.Bind<IBrandService>().To<BrandService>().InScope(cfg => HttpContext.Current);
            kernel.Bind<IScreenResolutionService>().To<ScreenResolutionService>().InScope(cfg => HttpContext.Current);
            kernel.Bind<IOsService>().To<OsService>().InScope(cfg => HttpContext.Current);
            kernel.Bind<IPhotoService>().To<PhotoService>().InScope(cfg => HttpContext.Current);
            kernel.Bind<IRolesService>().To<RolesService>().InScope(cfg => HttpContext.Current);
            kernel.Bind<ICommentsService>().To<CommentsService>().InScope(cfg => HttpContext.Current);

            var config = AutoMapperConfiguration.Configure();
            var mapper = config.CreateMapper();

            kernel.Bind<IMapper>().ToConstant(mapper);


            BusinessModule businessModule = new BusinessModule("Data Source=localhost;Initial Catalog=Catalog;Integrated Security=True");
            businessModule.Initialize(kernel);
        }
    }
}
