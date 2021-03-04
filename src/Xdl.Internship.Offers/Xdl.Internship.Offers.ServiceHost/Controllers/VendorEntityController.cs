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
        public async Task<ActionResult<IEnumerable<VendorForAdminDTO>>> GetVendorEntitiesById([FromRoute] string id)
        {
            if (!ObjectId.TryParse(id, out var parsedId))
            {
                return BadRequest($"{nameof(id)} is not valid");
            }

            return Ok(await _mediator.Send(new FindVendorEntityByIdRequest(parsedId)));
        }

        // offerId -> list of vendorEntities
        [HttpPost]
        [Route("api/vendorEntities/vendor/{vendorId}")]
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
        public async Task<ActionResult<VendorEntityDTO>> UpdateVendorEntity([FromRoute] string id, [FromBody] UpdateVendorEntityDTO vendorEntity)
        {
            if (!ObjectId.TryParse(id, out var parsedId))
            {
                return BadRequest($"{nameof(id)} is not valid");
            }

            return Ok(await _mediator.Send(new ReplaceVendorEntityRequest(parsedId, vendorEntity)));
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
