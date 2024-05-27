using DotNet8.CqrsDesignPattern.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.CqrsDesignPattern.Repositories.Blog
{
    public class BlogRepository : IBlogRepository
    {
        private readonly AppDbContext _appDbContext;

        public BlogRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<BlogModel> GetBlogByIdAsync(long id)
        {
            if (id <= 0)
                throw new Exception("Id cannot be empty.");

            var item = await _appDbContext.Blogs
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.BlogId == id);

            return item!;
        }

        public async Task<BlogListResponseModel> GetBlogsAsync()
        {
            var lst = await _appDbContext.Blogs
                .AsNoTracking()
                .OrderByDescending(x => x.BlogId)
                .ToListAsync();

            BlogListResponseModel responseModel = new()
            {
                DataLst = lst
            };

            return responseModel;
        }
    }
}
