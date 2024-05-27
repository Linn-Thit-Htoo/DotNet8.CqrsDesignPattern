using DotNet8.CqrsDesignPattern.Models;
using MediatR;

namespace DotNet8.CqrsDesignPattern.Queries.Blog.GetBlogById
{
    public class GetBlogByIdQuery : IRequest<BlogModel>
    {
        public long BlogId { get; set; }
    }
}
