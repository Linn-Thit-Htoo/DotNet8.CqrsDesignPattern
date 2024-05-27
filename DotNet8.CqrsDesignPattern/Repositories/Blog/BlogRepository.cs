using DotNet8.CqrsDesignPattern.Models;
using DotNet8.CqrsDesignPattern.Models.Blog;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace DotNet8.CqrsDesignPattern.Repositories.Blog
{
    public class BlogRepository : IBlogRepository
    {
        private readonly AppDbContext _appDbContext;

        public BlogRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<int> CreateBlogAsync(BlogRequestModel requestModel)
        {
            try
            {
                await _appDbContext.Blogs.AddAsync(requestModel.Change());
                int result = await _appDbContext.SaveChangesAsync();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<BlogModel> GetBlogByIdAsync(long id)
        {
            try
            {
                if (id <= 0)
                    throw new Exception("Id cannot be empty.");

                var item = await _appDbContext.Blogs
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.BlogId == id);

                return item!;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<BlogListResponseModel> GetBlogsAsync()
        {
            try
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
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
