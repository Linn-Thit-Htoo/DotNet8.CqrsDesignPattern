using DotNet8.CqrsDesignPattern.Queries;
using DotNet8.CqrsDesignPattern.Queries.Blog.GetBlogById;
using DotNet8.CqrsDesignPattern.Queries.Blog.GetBlogList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.CqrsDesignPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BlogController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetBlogs()
        {
            try
            {
                var query = new GetBlogQuery();
                var lst = await _mediator.Send(query);

                return Ok(lst);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBlogById(long id)
        {
            try
            {
                var query = new GetBlogByIdQuery() { BlogId = id };
                var item = await _mediator.Send(query);

                return Ok(item);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}