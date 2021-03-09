using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Xdl.Internship.Offers.Handlers.Vendor;
using Xdl.Internship.Offers.Models;
using Xdl.Internship.Offers.SDK.Identity;
using Xdl.Internship.Offers.SDK.VendorDTOs;

namespace Xdl.Internship.Offers.ServiceHost.Controllers
{
    [Authorize]
    [Controller]
    [Route("api/vendors")]
    public class VendorController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public VendorController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendorDTO>>> GetVendors([FromQuery]bool includeInactive = false)
        {
            return Ok(await _mediator.Send(new FindAllVendorsRequest(includeInactive)));
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<VendorWithEntitiesDTO>> GetVendorByIdWithEntities([FromRoute] string id, [FromQuery] bool includeEntities = false)
        {
            if (!ObjectId.TryParse(id, out var parsedId))
            {
                return BadRequest($"{nameof(id)} is not valid");
            }

            return Ok(await _mediator.Send(new FindVendorByIdRequest(parsedId, includeEntities)));
        }

        [HttpGet]
        [Route("city/{cityId}/vendorEntities")]
        public async Task<ActionResult<IEnumerable<VendorWithEntitiesDTO>>> GetVendorsByCityWithEntities([FromRoute]string cityId, [FromQuery]bool includeInactive = false)
        {
            if (!ObjectId.TryParse(cityId, out var id))
            {
                return BadRequest($"{nameof(cityId)} is not valid");
            }

            return Ok(await _mediator.Send(new FindVendorsByCityIdWithEntitiesRequest(id, !includeInactive)));
        }

        [Authorize(Roles = "Admin,Moderator")]
        [HttpPost]
        public async Task<ActionResult<VendorDTO>> CreateVendor([FromBody] CreateVendorDTO vendorDTO)
        {
            var identity = new CreateIdentity()
            {
                FirstName = User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.GivenName).Value,
                LastName = User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.Name).Value,
            };

            return Ok(await _mediator.Send(new InsertVendorRequest(vendorDTO, identity)));
        }

        [Authorize(Roles = "Admin,Moderator")]
        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<VendorDTO>> UpdateVendor([FromRoute] string id, [FromBody] UpdateVendorDTO vendorDTO)
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

            await _mediator.Publish(new ReplaceVendorRequest(parsedId, vendorDTO, identity));
            return Ok();
        }
    }
}
