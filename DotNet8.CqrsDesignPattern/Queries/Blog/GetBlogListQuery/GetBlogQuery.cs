using DotNet8.CqrsDesignPattern.Models.Blog;
using MediatR;

namespace DotNet8.CqrsDesignPattern.Queries.Blog.GetBlogListQuery
{
    public class GetBlogQuery : IRequest<BlogListResponseModel>
    {
    }
}
