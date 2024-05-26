using MediatR;

namespace DotNet8.CqrsDesignPattern.Commands
{
    public class CreateProductCommand : IRequest<int>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }
}
