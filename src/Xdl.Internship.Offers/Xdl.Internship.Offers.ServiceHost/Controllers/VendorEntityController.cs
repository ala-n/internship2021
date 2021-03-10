using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Xdl.Internship.Offers.Handlers.VendorEntity;
using Xdl.Internship.Offers.SDK.Identity;
using Xdl.Internship.Offers.SDK.VendorDTOs;
using Xdl.Internship.Offers.SDK.VendorEntityDTOs;

namespace Xdl.Internship.Offers.ServiceHost.Controllers
{
    [Authorize]
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
        public async Task<ActionResult<IEnumerable<VendorEntityWithVendorNameDTO>>> GetVendorEntitiesById([FromRoute] string id)
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

        [Authorize(Roles = "Admin,Moderator")]
        [HttpPost]
        [Route("api/vendors/{vendorId}/vendorEntities")]
        public async Task<ActionResult<VendorEntityDTO>> CreateVendorEntity([FromRoute] string vendorId, [FromBody] CreateVendorEntityDTO vendorEntity)
        {
            if (!ObjectId.TryParse(vendorId, out var parsedId))
            {
                return BadRequest($"{nameof(vendorId)} is not valid");
            }

            var identity = new CreateIdentity()
            {
                FirstName = User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.GivenName).Value,
                LastName = User.Claims.FirstOrDefault(u => u.Type == ClaimTypes.Name).Value,
            };

            return Ok(await _mediator.Send(new InsertVendorEntityRequest(parsedId, vendorEntity, identity)));
        }

        [Authorize(Roles = "Admin,Moderator")]
        [HttpPut]
        [Route("api/vendorEntities/{id}")]
        public async Task<ActionResult> UpdateVendorEntity([FromRoute] string id, [FromBody] UpdateVendorEntityDTO vendorEntity)
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

            await _mediator.Publish(new ReplaceVendorEntityRequest(parsedId, vendorEntity, identity));
            return Ok();
        }
    }
}
