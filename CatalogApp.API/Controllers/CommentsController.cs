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
        private ICommentsService commentsService;
        private IMapper mapper;

        public CommentsController(ICommentsService context, IMapper mapper)
        {
            commentsService = context;
            this.mapper = mapper;
        }

        // GET: api/Comments
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Comments/5
        public HttpResponseMessage Get(int id)
        {
            var comments = commentsService.GetComments(id);
            return Request.CreateResponse(HttpStatusCode.OK, mapper.Map<List<CommentVM>>(comments));
        }

        // POST: api/Comments
        public async Task<HttpResponseMessage> Post([FromBody]CommentVM comment)
        {
            var result = await commentsService.AddComment(mapper.Map<CommentDTO>(comment));

            if(result.isSucceed)
            {
                return Request.CreateResponse(HttpStatusCode.OK, result.Message);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, result.Message);
            }            
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
