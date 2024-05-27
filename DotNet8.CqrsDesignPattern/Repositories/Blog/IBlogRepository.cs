using DotNet8.CqrsDesignPattern.Models;

namespace DotNet8.CqrsDesignPattern.Repositories.Blog
{
    public interface IBlogRepository
    {
        Task<BlogListResponseModel> GetBlogsAsync();
        Task<BlogModel> GetBlogByIdAsync(long id);
    }
}
