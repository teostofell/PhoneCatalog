using CatalogApp.BLL.BusinessModel;
using CatalogApp.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatalogApp.BLL.Interfaces
{
    public interface ICommentsService
    {
        IEnumerable<CommentDTO> GetComments(int phoneId);
        Task<OperationDetails> AddComment(CommentDTO comment);
    }
}
