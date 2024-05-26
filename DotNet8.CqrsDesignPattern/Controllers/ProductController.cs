using DotNet8.CqrsDesignPattern.Commands;
using DotNet8.CqrsDesignPattern.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8.CqrsDesignPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ProductController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductCommand command)
        {
            var productId = await _mediator.Send(command);
            return Ok(productId);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var query = new GetProductQuery { Id = id };
            var product = await _mediator.Send(query);
            return Ok(product);
        }
    }
}
