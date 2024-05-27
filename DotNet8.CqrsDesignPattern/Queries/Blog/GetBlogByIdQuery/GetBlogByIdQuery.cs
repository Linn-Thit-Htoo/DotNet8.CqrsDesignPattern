using DotNet8.CqrsDesignPattern.Models.Blog;
using MediatR;

namespace DotNet8.CqrsDesignPattern.Queries.Blog.GetBlogByIdQuery;

public class GetBlogByIdQuery : IRequest<BlogModel>
{
    public long BlogId { get; set; }
}
