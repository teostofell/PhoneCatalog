using CatalogApp.BLL.Interfaces;
using CatalogApp.BLL.Services;
using CatalogApp.BLL.Utils;
using Ninject;
using Ninject.Web.Common.WebHost;
using System;
using System.Collections.Generic;
using System.Linq;
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
            kernel.Bind<IPhonesService>().To<PhonesService>();
            kernel.Bind<IFiltersService>().To<FiltersService>();
            kernel.Bind<IUserService>().To<UserService>();
            kernel.Bind<IOrdersService>().To<OrderService>();
            kernel.Bind<IOrderItemService>().To<OrderItemService>();


            BusinessModule businessModule = new BusinessModule("Data Source=localhost;Initial Catalog=Catalog;Integrated Security=True");
            businessModule.Initialize(kernel);
        }
    }
}
