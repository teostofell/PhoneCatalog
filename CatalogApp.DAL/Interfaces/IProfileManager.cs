using CatalogApp.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogApp.DAL.Interfaces
{
    public interface IProfileManager : IDisposable
    {
        void Create(UserProfile item);
    }
}
