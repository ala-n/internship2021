using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Xdl.Internship.Offers.Handlers.FavoriteOffer;
using Xdl.Internship.Offers.Handlers.Offer;
using Xdl.Internship.Offers.SDK.FavoriteOfferDTOs;
using Xdl.Internship.Offers.SDK.OfferDTOs;

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
            catch (Exception ex)
            {
                if (ex is NullReferenceException)
                {
                    return BadRequest("Please enter all necessary ");
                }
                else if (ex is IndexOutOfRangeException || ex is FormatException || ex is AutoMapperMappingException)
                {
                    return BadRequest("Please enter valid value");
                }

                throw;
            }
        }

        [HttpGet("{offerId}")]
        public async Task<ActionResult<FavoriteOfferDTO>> GetFavoriteUserOffers([FromRoute] string offerId)
        {
            try
            {
                return Ok(await _mediator.Send(new GetFavoriteUserOffersRequest(offerId,
                                User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value)));
            }
            catch (Exception ex)
            {
                if (ex is NullReferenceException)
                {
                    return BadRequest("Please enter all necessary field");
                }
                else if (ex is IndexOutOfRangeException || ex is FormatException || ex is AutoMapperMappingException)
                {
                    return BadRequest("Please enter valid value");
                }

                throw;
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
            catch (Exception ex)
            {
                if (ex is NullReferenceException)
                {
                    return BadRequest("Please enter all necessary field");
                }
                else if (ex is IndexOutOfRangeException || ex is FormatException || ex is AutoMapperMappingException)
                {
                    return BadRequest("Please enter valid value");
                }

                throw;
            }
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<OfferWithAllInfoDTO>>> GetAllFavoriteUserOffers()
        {
            try
            {
                List<OfferWithAllInfoDTO> result = new List<OfferWithAllInfoDTO>();
                ICollection<FavoriteOfferDTO> favourites = await _mediator.Send(new GetAllFavoriteUserOffersRequest(
                            User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value));

                foreach (var favourite in favourites)
                {
                    OfferWithAllInfoDTO offer = await _mediator.Send(new FindOfferByIdWithVendorInfoRequest(new ObjectId(favourite.OfferId)));
                    if (offer != null)
                    {
                    result.Add(offer);
                    }
                }

                return Ok(result);
            }
            catch (Exception ex)
            {
                if (ex is NullReferenceException)
                {
                    return BadRequest("smth went wrong");
                }
                else if (ex is IndexOutOfRangeException || ex is FormatException || ex is AutoMapperMappingException)
                {
                    return BadRequest("smth went wrong");
                }

                throw;
            }
        }
    }
}
