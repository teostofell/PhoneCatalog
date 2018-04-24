using AutoMapper;
using CatalogApp.BLL.BusinessModel;
using CatalogApp.BLL.DTO;
using CatalogApp.BLL.Interfaces;
using CatalogApp.DAL.Entities;
using CatalogApp.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Diagnostics;
using System.Threading.Tasks;

namespace CatalogApp.BLL.Services
{
    public class CommentsService : BaseService, ICommentsService
    {
        public CommentsService(IUnitOfWork db, IMapper mapper) : base(db, mapper) {}

        public async Task AddComment(CommentDto comment)
        {
            try
            {
                var result = UnitOfWork.Comments.Create(Mapper.Map<Comment>(comment));
            }
            catch(Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }

            var phone = await UnitOfWork.Phones.Get(comment.PhoneId).Include(p => p.Comments).FirstOrDefaultAsync();

            var average = phone.Comments.Select(c => c.Grade).Average();
            phone.Grade = Convert.ToInt32(average);
            UnitOfWork.Phones.Update(phone);

            try
            {
                await UnitOfWork.SaveAsync();
            }
            catch(Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }
        }

        public IEnumerable<CommentDto> GetComments(int phoneId)
        {
            List<Comment> comments;
            List<CommentDto> commentsDto;

            try
            {
                comments = UnitOfWork.Comments.GetAll().Where(c => c.PhoneId == phoneId)
                    .Include(c => c.User).ToList();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }

            try
            {
                commentsDto = Mapper.Map<List<CommentDto>>(comments);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                throw;
            }

            return commentsDto;
        }
    }
}
