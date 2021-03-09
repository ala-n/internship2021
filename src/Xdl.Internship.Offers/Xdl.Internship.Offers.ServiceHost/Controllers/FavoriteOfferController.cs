using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xdl.Internship.Offers.Handlers.FavoriteOffer;
using Xdl.Internship.Offers.SDK.FavoriteOfferDTOs;

namespace Xdl.Internship.Offers.ServiceHost.Controllers
{
    [Authorize]
    [Route("api/favoriteOffer")]
    [ApiController]
    public class FavoriteOfferController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FavoriteOfferController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("add/{offerId}")]
        public async Task<ActionResult<FavoriteOfferDTO>> AddFavoriteUserOffers([FromRoute] string offerId)
        {
            try
            {
                return Ok(await _mediator.Send(new AddFavoriteUserOfferRequest(offerId,
                                User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value)));
            }
            catch (NullReferenceException)
            {
                return BadRequest();
            }
        }

        [HttpGet("{offerId}")]
        public async Task<ActionResult<FavoriteOfferDTO>> GetFavoriteUserOffers([FromRoute] string offerId)
        {
            return Ok(await _mediator.Send(new GetFavoriteUserOffersRequest(offerId,
                            User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value)));
        }

        [HttpGet("all")]
        public async Task<ActionResult<ICollection<FavoriteOfferDTO>>> GetAllFavoriteUserOffers()
        {
            try
            {
                return Ok(await _mediator.Send(new GetAllFavoriteUserOffersRequest(
                            User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value)));
            }
            catch (NullReferenceException)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{offerId}")]
        public async Task<IActionResult> DeleteFavoriteUserOffer([FromRoute] string offerId)
        {
            try
            {
                return Ok(await _mediator.Send(new DeleteFavoriteUserOfferRequest(offerId,
                     User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value)));
            }
            catch (NullReferenceException)
            {
                return BadRequest();
            }
        }
    }
}
