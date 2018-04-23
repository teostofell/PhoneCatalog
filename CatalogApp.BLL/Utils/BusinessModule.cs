using CatalogApp.DAL.Interfaces;
using Ninject;
using CatalogApp.DAL.Repositories.MSSQL;

namespace CatalogApp.BLL.Utils
{
    public class BusinessModule
    {
        private string ConnectionString { get; }

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
