using CatalogApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ninject.Modules;
using System.Threading.Tasks;
using Ninject;
using CatalogApp.DAL.Repositories.MSSQL;

namespace CatalogApp.BLL.Utils
{
    public class BusinessModule
    {
        public string ConnectionString { get; set; }

        public BusinessModule(string connectionString)
        {
            ConnectionString = connectionString;
        }

        public void Initialize(IKernel kernel)
        {
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(ConnectionString);
        }
    }
}
