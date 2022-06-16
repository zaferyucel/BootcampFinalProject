using BootcampFinalProject.Application.Features.Commands.OfferCommands;
using BootcampFinalProject.Application.Features.Commands.OfferCommands.DeleteOffer;
using BootcampFinalProject.Application.Features.Queries.OfferQueries.GetAllOffers;
using BootcampFinalProject.Application.Features.Queries.OfferQueries.GetByProductIdOffer;
using BootcampFinalProject.Application.Features.Queries.OfferQueries.GetByUserIdOffer;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BootcampFinalProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OffersController : ControllerBase
    {
        IMediator _mediator;

        public OffersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOffer([FromBody] CreateOfferCommandRequest request)
        {
            CreateOfferCommandResponse response = await _mediator.Send(request);
            return Ok(request);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            List<GetAllOffersQueryResponse> response = await _mediator.Send(new GetAllOffersQueryRequest());
            return Ok(response);
        }

        [HttpGet("(productId)")]
        public async Task<IActionResult> GetByProductId(string id)
        {
            IEnumerable<GetByProductIdOfferQueryResponse> response =await _mediator.Send(new GetByProductIdOfferQueryRequest { Id = id });
            return Ok(response);
        }

        [HttpGet("(userId)")]
        public async Task<IActionResult> GetByUserId(string id)
        {
            IEnumerable < GetByUserIdOfferQueryResponse > response = await _mediator.Send(new GetByUserIdOfferQueryRequest { Id = id });
            return Ok(response);
        }



        [HttpDelete("{userId}/{productId}")]
        public async Task<IActionResult> DeleteOffer(int userId, int productId)
        {
            DeleteOfferCommandResponse response = await _mediator.Send(new DeleteOfferCommandRequest {  UserId = userId, ProductId = productId });
            return Ok(response);

        }
    }
}