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
    public class CommentsService : ICommentsService
    {
        private IUnitOfWork Db { get; set; }
        private IMapper mapper;

        public CommentsService(IUnitOfWork db, IMapper mapper)
        {
            Db = db;
            this.mapper = mapper;
        }

        public async Task<OperationDetails> AddComment(CommentDTO comment)
        {
            try
            {
                var result = Db.Comments.Create(mapper.Map<Comment>(comment));
            }
            catch(Exception e)
            {
                return new OperationDetails(false, "Error on creating comment");
            }

            var phone = await Db.Phones.Get(comment.PhoneId).Include(p => p.Comments).FirstOrDefaultAsync();

            var average = phone.Comments.Select(c => c.Grade).Average();
            phone.Grade = Convert.ToInt32(average);
            Db.Phones.Update(phone);

            try
            {
                await Db.SaveAsync();
            }
            catch(Exception e)
            {
                return new OperationDetails(false, "Error on saving changes");
            }

            return new OperationDetails(true, "Comment has been added");

        }

        public IEnumerable<CommentDTO> GetComments(int phoneId)
        {
            var comments = Db.Comments.GetAll().Where(c => c.PhoneId == phoneId)
                .Include(c => c.User).ToList();

            return mapper.Map<List<CommentDTO>>(comments);
        }

        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
