﻿using DotNet8.CqrsDesignPattern.Models;
using DotNet8.CqrsDesignPattern.Repositories.Blog;
using MediatR;

namespace DotNet8.CqrsDesignPattern.Queries.Blog.GetBlogById
{
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, BlogModel>
    {
        private readonly IBlogRepository _blogRepository;

        public GetBlogByIdQueryHandler(IBlogRepository blogRepository)
        {
            _blogRepository = blogRepository;
        }

        public async Task<BlogModel> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            return await _blogRepository.GetBlogByIdAsync(request.BlogId);
        }
    }
}
