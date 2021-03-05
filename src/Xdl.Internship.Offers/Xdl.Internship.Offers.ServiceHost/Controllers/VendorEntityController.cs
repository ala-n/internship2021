﻿using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Xdl.Internship.Offers.Handlers.VendorEntity;
using Xdl.Internship.Offers.SDK.VendorDTOs;
using Xdl.Internship.Offers.SDK.VendorEntityDTOs;

namespace Xdl.Internship.Offers.ServiceHost.Controllers
{
    [Controller]
    public class VendorEntityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VendorEntityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("api/vendorEntities/{id}")]
        public async Task<ActionResult<IEnumerable<VendorDTO>>> GetVendorEntitiesById([FromRoute] string id)
        {
            if (!ObjectId.TryParse(id, out var parsedId))
            {
                return BadRequest($"{nameof(id)} is not valid");
            }

            return Ok(await _mediator.Send(new FindVendorEntityByIdRequest(parsedId)));
        }

        [HttpGet]
        [Route("api/vendorEntities/vendor/{vendorId}")]
        public async Task<ActionResult<ICollection<VendorDTO>>> GetEntitiesByVendorId([FromRoute]string vendorId, bool includeInactive = false)
        {
            if (!ObjectId.TryParse(vendorId, out var parsedId))
            {
                return BadRequest($"{nameof(vendorId)} is not valid");
            }

            return Ok(await _mediator.Send(new FindVendorEntitiesByVendorIdRequest(parsedId, includeInactive)));
        }

        // offerId -> list of vendorEntities
        [HttpPost]
        [Route("api/vendors/{vendorId}/vendorEntities")]
        public async Task<ActionResult<VendorEntityDTO>> CreateVendorEntity([FromRoute] string vendorId, [FromBody] CreateVendorEntityDTO vendorEntity)
        {
            if (!ObjectId.TryParse(vendorId, out var parsedId))
            {
                return BadRequest($"{nameof(vendorId)} is not valid");
            }

            return Ok(await _mediator.Send(new InsertVendorEntityRequest(parsedId, vendorEntity)));
        }

        [HttpPut]
        [Route("api/vendorEntities/{id}")]
        public async Task<ActionResult> UpdateVendorEntity([FromRoute] string id, [FromBody] UpdateVendorEntityDTO vendorEntity)
        {
            if (!ObjectId.TryParse(id, out var parsedId))
            {
                return BadRequest($"{nameof(id)} is not valid");
            }

            await _mediator.Publish(new ReplaceVendorEntityRequest(parsedId, vendorEntity));
            return Ok();
        }

        [HttpDelete]
        [Route("api/vendorEntities/{id}")]
        public async Task<ActionResult> DeleteVendorEntity([FromRoute] string id)
        {
            if (!ObjectId.TryParse(id, out var parsedId))
            {
                return BadRequest($"{nameof(id)} is not valid");
            }

            return Ok(await _mediator.Send(new DeleteVendorEntityRequest(parsedId)));
        }
    }
}
