﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Xdl.Internship.Offers.Handlers.Offer;
using Xdl.Internship.Offers.SDK.OfferDTOs;
using Xdl.Internship.Offers.SDK.VendorDTOs;

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<OfferWithVendorNameDTO>>> GetAllWithVendorInfo([FromQuery] bool includeInactive)
        {
            return Ok(await _mediator.Send(new FindAllOffersWithVendorInfoRequest(includeInactive)));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<OfferWithAllInfoDTO>> GetOfferInfoByOfferId([FromRoute] string id)
        {
            if (!ObjectId.TryParse(id, out var parsedId))
            {
                return BadRequest($"{nameof(id)} is not valid");
            }

            return Ok(await _mediator.Send(new FindOfferByIdWithVendorInfoRequest(parsedId)));
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
        public async Task<ActionResult<IEnumerable<OfferMainDTO>>> FindOffersByVendorId([FromRoute] string vendorId, [FromQuery] bool includeInactive = false)
        {
            if (!ObjectId.TryParse(vendorId, out var id))
            {
                return BadRequest($"{nameof(vendorId)} is not valid");
            }

            return Ok(await _mediator.Send(new FindOffersByVendorIdRequest(id, includeInactive)));
        }

        [HttpGet]
        [Route("vendor/{vendorId}/vendorInfo")]
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
        public async Task<ActionResult<IEnumerable<OfferMainDTO>>> FindOfferByVendorEntityId([FromRoute] string vendorEntityId)
        {
            if (!ObjectId.TryParse(vendorEntityId, out var id))
            {
                return BadRequest($"{nameof(vendorEntityId)} is not valid");
            }

            return Ok(await _mediator.Send(new FindOfferByVendorEntityIdRequest(id)));
        }

        [HttpPost]
        public async Task<ActionResult<OfferMainDTO>> CreateOffer([FromBody] CreateOfferDTO offerDTO)
        {
            return Ok(await _mediator.Send(new InsertOfferRequest(offerDTO)));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<OfferMainDTO>> UpdateOffer([FromRoute] string id, [FromBody] UpdateOfferDTO offerDTO)
        {
            if (!ObjectId.TryParse(id, out var parsedId))
            {
                return BadRequest($"{nameof(id)} is not valid");
            }

            return Ok(await _mediator.Send(new ReplaceOfferRequest(parsedId, offerDTO)));
        }
    }
}
