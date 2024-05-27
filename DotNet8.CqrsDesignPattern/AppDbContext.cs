using DotNet8.CqrsDesignPattern.Models.Blog;
using Microsoft.EntityFrameworkCore;

namespace DotNet8.CqrsDesignPattern;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<BlogModel> Blogs { get; set; }
}