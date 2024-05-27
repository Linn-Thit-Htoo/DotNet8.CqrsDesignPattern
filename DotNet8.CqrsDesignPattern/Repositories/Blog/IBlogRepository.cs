using DotNet8.CqrsDesignPattern.Models.Blog;

namespace DotNet8.CqrsDesignPattern.Repositories.Blog;

public interface IBlogRepository
{
    Task<BlogListResponseModel> GetBlogsAsync();
    Task<BlogModel> GetBlogByIdAsync(long id);
    Task<int> CreateBlogAsync(BlogRequestModel requestModel);
}