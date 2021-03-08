using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Xdl.Internship.Offers.Handlers.FavoriteOffer;
using Xdl.Internship.Offers.SDK.FavoriteOfferDTOs;

namespace Xdl.Internship.Offers.ServiceHost.Controllers
{
    [Route("api/favoriteOffer")]
    [ApiController]
    public class FavoriteOfferController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FavoriteOfferController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("{offerId}")]
        public async Task<ActionResult<FavoriteOfferDTO>> AddFavoriteUserOffers([FromRoute] string offerId)
        {
            throw new Exception(); /*return Ok(await _mediator.Send());*/
        }

        [HttpGet("{offerId}")]
        public async Task<ActionResult<FavoriteOfferDTO>> GetFavoriteUserOffers([FromRoute] string offerId)
        {
            throw new Exception(); /*return Ok(await _mediator.Send());*/
        }

        [HttpGet("all/{offerId}")]
        public async Task<ActionResult<ICollection<FavoriteOfferDTO>>> GetAllFavoriteUserOffers([FromRoute] string offerId)
        {
            try
            {
                return Ok(await _mediator.Send(new GetAllFavoriteUserOffersRequest(
                            offerId,
                            User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value)));
            }
            catch (NullReferenceException)
            {
                return BadRequest();
            }
        }

        [HttpDelete("{offerId}")]
        public async Task DeleteFavoriteUserOffer([FromRoute] string offerId)
        {
             throw new Exception(); /*return Ok(await _mediator.Send());*/
        }
    }
}
