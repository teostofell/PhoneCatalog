using CatalogApp.BLL.BusinessModel;
using CatalogApp.BLL.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CatalogApp.BLL.Interfaces
{
    public interface ICommentsService
    {
        IEnumerable<CommentDto> GetComments(int phoneId);
        Task AddComment(CommentDto comment);
    }
}
