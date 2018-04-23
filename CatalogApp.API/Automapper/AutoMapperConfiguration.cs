using AutoMapper;
using CatalogApp.BLL.Automapper;

namespace CatalogApp.API.Automapper
{
    public class AutoMapperConfiguration
    {
        public static MapperConfiguration Configure()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DtoToVmProfile>();
                cfg.AddProfile<EntityToDtoProfile>();
            });

            return config;
        }
    }
}