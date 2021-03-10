using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Xdl.Internship.Offers.Handlers.Offer;
using Xdl.Internship.Offers.SDK.Identity;
using Xdl.Internship.Offers.SDK.OfferDTOs;
using Xdl.Internship.Offers.SDK.VendorDTOs;

namespace Xdl.Internship.Offers.ServiceHost.Controllers
{
    [Authorize]
    [Controller]
    [Route("api/offers")]
    public class OfferController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OfferController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfferWithVendorNameDTO>>> GetAllWithVendorInfo([FromQuery] bool includeInactive)
        {
            return Ok(await _mediator.Send(new FindAllOffersWithVendorInfoRequest(includeInactive)));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<OfferWithAllInfoDTO>> GetOfferInfoByOfferId([FromRoute] string id, [FromQuery] bool metricsView = false)
        {
            if (!ObjectId.TryParse(id, out var parsedId))
            {
                return BadRequest($"{nameof(id)} is not valid");
            }

            return Ok(await _mediator.Send(new FindOfferByIdWithVendorInfoRequest(parsedId, metricsView)));
        }

        [HttpGet]
        [Route("city/{cityId}")]
        public async Task<ActionResult<IEnumerable<OfferWithVendorInfoDTO>>> FindOffersByCityId([FromRoute]string cityId)
        {
            if (!ObjectId.TryParse(cityId, out var id))
            {
                return BadRequest($"{nameof(cityId)} is not valid");
            }

            return Ok(await _mediator.Send(new FindOffersByCityIdRequest(id, true)));
        }

        [HttpGet]
        [Route("vendor/{vendorId}")]
        public async Task<ActionResult<IEnumerable<OfferWithVendorNameDTO>>> GetOffersByVendorIdWithVendorInfo([FromRoute] string vendorId, [FromQuery] bool includeInactive = false)
        {
            if (!ObjectId.TryParse(vendorId, out var id))
            {
                return BadRequest($"{nameof(vendorId)} is not valid");
            }

            return Ok(await _mediator.Send(new FindOffersByVendorIdWithVendorInfoRequest(id, includeInactive)));
        }

        [HttpGet]
        [Route("vendorEntity/{vendorEntityId}")]
        public async Task<ActionResult<IEnumerable<OfferMainDTO>>> FindOfferByVendorEntityId([FromRoute] string vendorEntityId, [FromQuery] bool includeInactive = false)
        {
            if (!ObjectId.TryParse(vendorEntityId, out var id))
            {
                return BadRequest($"{nameof(vendorEntityId)} is not valid");
            }

            return Ok(await _mediator.Send(new FindOfferByVendorEntityIdRequest(id, includeInactive)));
        }

        [Authorize(Roles = "Admin,Moderator")]
        [HttpPost]
        public async Task<ActionResult<OfferMainDTO>> CreateOffer([FromBody] CreateOfferDTO offerDTO)
        {
            var identity = new CreateIdentity()
            {
                FirstName = User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.GivenName).Value,
                LastName = User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.Name).Value,
            };

            return Ok(await _mediator.Send(new InsertOfferRequest(offerDTO, identity)));
        }

        [Authorize(Roles = "Admin,Moderator")]
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<OfferMainDTO>> UpdateOffer([FromRoute] string id, [FromBody] UpdateOfferDTO offerDTO)
        {
            if (!ObjectId.TryParse(id, out var parsedId))
            {
                return BadRequest($"{nameof(id)} is not valid");
            }

            var identity = new UpdateIdentity()
            {
                FirstName = User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.GivenName).Value,
                LastName = User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.Name).Value,
            };

            return Ok(await _mediator.Send(new ReplaceOfferRequest(parsedId, offerDTO, identity)));
        }
    }
}
