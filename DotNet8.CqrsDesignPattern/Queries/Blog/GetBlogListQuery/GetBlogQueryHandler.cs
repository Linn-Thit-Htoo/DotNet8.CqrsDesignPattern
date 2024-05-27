using DotNet8.CqrsDesignPattern.Models.Blog;
using DotNet8.CqrsDesignPattern.Repositories.Blog;
using MediatR;

namespace DotNet8.CqrsDesignPattern.Queries.Blog.GetBlogList
{
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, BlogListResponseModel>
    {
        private readonly IBlogRepository _blogRepository;

        public GetBlogQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<BlogListResponseModel> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            return await _blogRepository.GetBlogsAsync();
        }
    }
}
