using DotNet8.CqrsDesignPattern.Models.Blog;

namespace DotNet8.CqrsDesignPattern.Models;

public static class ChangeModel
{
    public static BlogModel Change(this BlogRequestModel requestModel)
    {
        return new BlogModel
        {
            BlogTitle = requestModel.BlogTitle,
            BlogAuthor = requestModel.BlogAuthor,
            BlogContent = requestModel.BlogContent
        };
    }
}