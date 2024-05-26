using DotNet8.CqrsDesignPattern.Models;
using MediatR;

namespace DotNet8.CqrsDesignPattern.Queries
{
    public class GetProductQuery : IRequest<Product>
    {
        public int Id { get; set; }
    }
}
