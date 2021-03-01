using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Xdl.Internship.Offers.Handlers.Offer;
using Xdl.Internship.Offers.SDK.OfferDTOs;

namespace Xdl.Internship.Offers.ServiceHost.Controllers
{
    [Controller]
    [Route("api/offers")]
    public class OfferController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OfferController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // [HttpGet("GetAll")]
        // public async Task<IEnumerable<OfferDTO>> GetAll()
        // {
        //    return await _mediator.Send(new FindActiveOffersRequest());
        // }
        [HttpGet("{cityId}")]
        public async Task<ActionResult<IEnumerable<OfferForListDTO>>> FindOffersByCityId([FromRoute]string cityId)
        {
            if (!ObjectId.TryParse(cityId, out var id))
            {
                return BadRequest($"{nameof(cityId)} is not valid");
            }

            return Ok(await _mediator.Send(new FindOffersByCityIdRequest(id, true)));
        }

        [HttpGet("{offerId}")]
        public async Task<ActionResult<IEnumerable<OfferMainDTO>>> FindOfferById([FromRoute] string offerId)
        {
            if (!ObjectId.TryParse(offerId, out var id))
            {
                return BadRequest($"{nameof(offerId)} is not valid");
            }

            return Ok(await _mediator.Send(new FindOfferByIdRequest(id)));
        }

        [HttpGet("{vendorId}")]
        public async Task<ActionResult<IEnumerable<OfferMainDTO>>> FindOffersByVendorId([FromRoute] string vendorId)
        {
            if (!ObjectId.TryParse(vendorId, out var id))
            {
                return BadRequest($"{nameof(vendorId)} is not valid");
            }

            return Ok(await _mediator.Send(new FindOffersByVendorIdRequest(id)));
        }

        [HttpGet("{vendorEntityId}")]
        public async Task<ActionResult<IEnumerable<OfferMainDTO>>> FindOfferByVendorEntityId([FromRoute] string vendorEntityId)
        {
            if (!ObjectId.TryParse(vendorEntityId, out var id))
            {
                return BadRequest($"{nameof(vendorEntityId)} is not valid");
            }

            return Ok(await _mediator.Send(new FindOfferByVendorEntityIdRequest(id)));
        }
    }
}
