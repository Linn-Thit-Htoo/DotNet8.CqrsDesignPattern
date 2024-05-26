using DotNet8.CqrsDesignPattern.Models;
using MediatR;

namespace DotNet8.CqrsDesignPattern.Commands
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
    {
        private readonly List<Product> _products = new List<Product>();
        private int _nextProductId = 1;

        public async Task<int> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            // Simulate creating a new product
            var product = new Product
            {
                Id = _nextProductId++,
                Name = request.Name,
                Price = request.Price
            };

            // Add the product to the fake data source
            _products.Add(product);

            // Return the newly created product's ID
            return product.Id;
        }
    }
}
