using BootcampFinalProject.Application.Features.Commands.ProductCommands.CreateProduct;
using BootcampFinalProject.Application.Features.Commands.ProductCommands.DeleteProduct;
using BootcampFinalProject.Application.Features.Commands.ProductCommands.UpdateProduct;
using BootcampFinalProject.Application.Features.Queries.ProductQueries.GetAllProducts;
using BootcampFinalProject.Application.Features.Queries.ProductQueries.GetByIdProduct;
using Microsoft.AspNetCore.Authorization;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BootcampFinalProject.Application.Features.Commands.ProductCommands.BuyProduct;
using BootcampFinalProject.Application.Features.Queries.ProductQueries.SearchProduct;

namespace BootcampFinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<GetAllProductQueryResponse> response = await _mediator.Send(new GetAllProductQueryRequest());
            return Ok(response);
        }

       

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            GetByIdProductQueryResponse response = await _mediator.Send(new GetByIdProductQueryRequest { Id = id });
            return Ok(response);
        }

        // [Authorize(AuthenticationSchemes = "LoggedUser")]
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductCommandRequest request)
        {
            CreateProductCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromForm] UpdateProductCommandRequest request)
        {
            UpdateProductCommandResponse response = await _mediator.Send(request);
            return Ok(request);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            DeleteProductCommandResponse response = await _mediator.Send(new DeleteProductCommandRequest { Id = id });
            return Ok(response);
        }

        [HttpPost("buy{id}")]
        public async Task<IActionResult> BuyProductQuery(int id)
        {
            BuyProductCommandResponse response = await _mediator.Send(new BuyProductCommandRequest { ProductId = id });
            return Ok(response);
        }
        [HttpGet("search")]
        public async Task<IActionResult> SearchProductQuery([FromQuery] SearchProductQueryRequest request)
        {
            IEnumerable<SearchProductQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }


    }
}

