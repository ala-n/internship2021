using System.Collections.Generic;
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
            if (!ObjectId.TryParse(id, out var vendorEntityId))
            {
                return BadRequest($"{nameof(id)} is not valid");
            }

            return Ok(await _mediator.Send(new FindVendorEntityByIdRequest(vendorEntityId)));
        }

        [HttpPost]
        [Route("api/vendors/{vendorId}/vendorEntities")]
        public async Task<ActionResult<VendorEntityDTO>> CreateVendorEntity([FromRoute] string vendorId, [FromBody] CreateVendorEntityDTO vendorEntity)
        {
            if (!ObjectId.TryParse(vendorId, out var id))
            {
                return BadRequest($"{nameof(vendorId)} is not valid");
            }

            return Ok(await _mediator.Send(new InsertVendorEntityRequest(vendorEntity, id)));
        }
    }
}
