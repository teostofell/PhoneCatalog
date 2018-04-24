using System;
using AutoMapper;
using CatalogApp.API.Models;
using CatalogApp.BLL.DTO;
using CatalogApp.BLL.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;
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

        // GET: api/Comments/5
        public HttpResponseMessage Get(int id)
        {
            HttpResponseMessage response;
            try
            {
                var comments = _commentsService.GetComments(id);
                response = Request.CreateResponse(HttpStatusCode.OK, _mapper.Map<List<CommentViewModel>>(comments));
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);
                response = Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }

            return response;
        }

        // POST: api/Comments
        public async Task<HttpResponseMessage> Post([FromBody]CommentViewModel comment)
        {
            try
            {
                await _commentsService.AddComment(_mapper.Map<CommentDto>(comment));
            }
            catch (Exception e)
            {
                Debug.WriteLine(e);

                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
