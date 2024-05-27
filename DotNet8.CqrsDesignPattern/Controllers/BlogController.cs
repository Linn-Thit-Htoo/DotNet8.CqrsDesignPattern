using DotNet8.CqrsDesignPattern.Commands.Blog.CreateBlogCommand;
using DotNet8.CqrsDesignPattern.Models.Blog;
using DotNet8.CqrsDesignPattern.Queries.Blog.GetBlogByIdQuery;
using DotNet8.CqrsDesignPattern.Queries.Blog.GetBlogListQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.CqrsDesignPattern.Controllers;

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

    [HttpPost]
    public async Task<IActionResult> CreateBlog([FromBody] BlogRequestModel requestModel)
    {
        try
        {
            var command = new CreateBlogCommand() { Blog = requestModel };
            int result = await _mediator.Send(command);

            return result > 0 ? StatusCode(201, "Blog Created.") : BadRequest("Creating Fail.");
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
}