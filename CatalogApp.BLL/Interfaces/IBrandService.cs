﻿using CatalogApp.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogApp.BLL.Interfaces
{
    public interface IBrandService : IDisposable
    {
        IEnumerable<BrandDTO> GetBrands();
    }
}