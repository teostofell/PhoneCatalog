using AutoMapper;
using CatalogApp.API.Models;
using CatalogApp.BLL.DTO;
using CatalogApp.BLL.Interfaces;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace CatalogApp.API.Controllers
{
    public class CommentsController : ApiController
    {
        private readonly ICommentsService _commentsService;
        private readonly IMapper _mapper;

        public CommentsController(ICommentsService context, IMapper mapper)
        {
            _commentsService = context;
            _mapper = mapper;
        }

        // GET: api/Comments
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Comments/5
        public HttpResponseMessage Get(int id)
        {
            var comments = _commentsService.GetComments(id);
            return Request.CreateResponse(HttpStatusCode.OK, _mapper.Map<List<CommentVm>>(comments));
        }

        // POST: api/Comments
        public async Task<HttpResponseMessage> Post([FromBody]CommentVm comment)
        {
            var result = await _commentsService.AddComment(_mapper.Map<CommentDto>(comment));

            if(result.IsSucceed)
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
