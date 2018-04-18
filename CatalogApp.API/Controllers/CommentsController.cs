using AutoMapper;
using CatalogApp.API.Models;
using CatalogApp.BLL.DTO;
using CatalogApp.BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CatalogApp.API.Controllers
{
    public class CommentsController : ApiController
    {
        private ICommentsService db;
        private IMapper mapper;

        public CommentsController(ICommentsService context)
        {
            db = context;
            mapper = new MapperConfiguration(cfg => {
                cfg.CreateMap<CommentDTO, CommentVM>();
                cfg.CreateMap<UserDTO, UserVM>();
            }).CreateMapper();

        }

        // GET: api/Comments
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Comments/5
        public HttpResponseMessage Get(int id)
        {
            var comments = db.GetComments(id);
            return Request.CreateResponse(HttpStatusCode.OK, mapper.Map<List<CommentVM>>(comments));
        }

        // POST: api/Comments
        public async Task<HttpResponseMessage> Post([FromBody]CommentVM comment)
        {
            var result = await db.AddComment(mapper.Map<CommentDTO>(comment));
            return Request.CreateResponse("asf");
        }

        // PUT: api/Comments/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Comments/5
        public void Delete(int id)
        {
        }
    }
}
