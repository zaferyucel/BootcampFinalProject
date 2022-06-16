using BootcampFinalProject.Application.Features.Commands.CategoryCommands.CreateCategory;
using BootcampFinalProject.Application.Features.Commands.CategoryCommands.DeleteCategory;
using BootcampFinalProject.Application.Features.Commands.CategoryCommands.UpdateCategory;
using BootcampFinalProject.Application.Features.Queries.CategoryQueries.GetAllCategories;
using BootcampFinalProject.Application.Features.Queries.CategoryQueries.GetByIdCategory;
using BootcampFinalProject.Application.Features.Queries.CategoryQueries.SearchCategory;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BootcampFinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List <GetAllCategoriesQueryResponse> response = (List<GetAllCategoriesQueryResponse>)await _mediator.Send(new GetAllCategoriesQueryRequest());
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            GetByIdCategoryQueryResponse response = await _mediator.Send(new GetByIdCategoryQueryRequest { Id = id });
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommandRequest request)
        {
            CreateCategoryCommandResponse response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory([FromForm] UpdateCategoryCommandRequest request)
        {
            UpdateCategoryCommandResponse response =  await _mediator.Send(request);
            return Ok(response);
        }
     
        

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            DeleteCategoryCommandResponse response = await _mediator.Send(new DeleteCategoryCommandRequest { Id = id });
            return Ok(response);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchCategoryQuery([FromQuery] SearchCategoryQueryRequest request)
        {
            IEnumerable<SearchCategoryQueryResponse> response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
