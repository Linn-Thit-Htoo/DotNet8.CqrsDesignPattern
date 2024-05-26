using DotNet8.CqrsDesignPattern.Models;
using MediatR;

namespace DotNet8.CqrsDesignPattern.Queries
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, Product>
    {
        private readonly List<Product> _products = new List<Product>
        {
            new Product { Id = 1, Name = "Product A", Price = 10.99m },
            new Product { Id = 2, Name = "Product B", Price = 19.99m },
        };

        public async Task<Product> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = _products.FirstOrDefault(p => p.Id == request.Id) ?? throw new($"Product with ID {request.Id} not found.");
            return product;
        }
    }
}
