using AutoMapper;
using CatalogApp.BLL.BusinessModel;
using CatalogApp.BLL.DTO;
using CatalogApp.BLL.Interfaces;
using CatalogApp.DAL.Entities;
using CatalogApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace CatalogApp.BLL.Services
{
    public class CommentsService : BaseService, ICommentsService
    {
        public CommentsService(IUnitOfWork db, IMapper mapper) : base(db, mapper) {}

        public async Task<OperationDetails> AddComment(CommentDTO comment)
        {
            try
            {
                var result = unitOfWork.Comments.Create(mapper.Map<Comment>(comment));
            }
            catch(Exception e)
            {
                return new OperationDetails(false, "Error on creating comment");
            }

            var phone = await unitOfWork.Phones.Get(comment.PhoneId).Include(p => p.Comments).FirstOrDefaultAsync();

            var average = phone.Comments.Select(c => c.Grade).Average();
            phone.Grade = Convert.ToInt32(average);
            unitOfWork.Phones.Update(phone);

            try
            {
                await unitOfWork.SaveAsync();
            }
            catch(Exception e)
            {
                return new OperationDetails(false, "Error on saving changes");
            }

            return new OperationDetails(true, "Comment has been added");

        }

        public IEnumerable<CommentDTO> GetComments(int phoneId)
        {
            var comments = unitOfWork.Comments.GetAll().Where(c => c.PhoneId == phoneId)
                .Include(c => c.User).ToList();

            return mapper.Map<List<CommentDTO>>(comments);
        }
    }
}
