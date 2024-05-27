using DotNet8.CqrsDesignPattern.Repositories.Blog;
using MediatR;

namespace DotNet8.CqrsDesignPattern.Commands.Blog.CreateBlogCommand;

public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, int>
{
    private readonly IBlogRepository _blogRepository;

    public CreateBlogCommandHandler(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task<int> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
    {
        return await _blogRepository.CreateBlogAsync(request.Blog);
    }
}
