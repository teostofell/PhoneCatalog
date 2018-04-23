using CatalogApp.BLL.DTO;
using System.Collections.Generic;

namespace CatalogApp.BLL.Interfaces
{
    public interface IScreenResolutionService
    {
        IEnumerable<ScreenResolutionDto> GetScreenResolutions();
    }
}
