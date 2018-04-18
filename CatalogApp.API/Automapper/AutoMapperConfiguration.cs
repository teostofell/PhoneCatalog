using AutoMapper;
using CatalogApp.BLL.Automapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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