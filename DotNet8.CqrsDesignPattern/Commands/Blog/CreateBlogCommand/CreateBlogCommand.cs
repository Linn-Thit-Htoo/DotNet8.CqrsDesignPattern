using DotNet8.CqrsDesignPattern.Models.Blog;
using MediatR;

namespace DotNet8.CqrsDesignPattern.Commands.Blog.CreateBlogCommand;

public class CreateBlogCommand : IRequest<int>
{
    public BlogRequestModel Blog { get; set; }
}