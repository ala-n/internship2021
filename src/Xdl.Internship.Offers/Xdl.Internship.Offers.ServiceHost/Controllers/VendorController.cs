using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Xdl.Internship.Offers.Handlers.Vendor;
using Xdl.Internship.Offers.SDK.VendorDTOs;

namespace Xdl.Internship.Offers.ServiceHost.Controllers
{
    [Controller]
    [Route("api/vendors")]
    public class VendorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public VendorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendorDTO>>> GetAllVendors()
        {
            return Ok(await _mediator.Send(new FindActiveVendorsRequest()));
        }

        [HttpGet]
        [Route("{vendorId}")]
        public async Task<ActionResult<VendorWithEntitiesDTO>> GetVendorByIdWithEntities([FromRoute] string vendorId, [FromQuery] bool includeEntities = false)
        {
            if (!ObjectId.TryParse(vendorId, out var id))
            {
                return BadRequest($"{nameof(vendorId)} is not valid");
            }

            return Ok(await _mediator.Send(new FindVendorByIdRequest(id, includeEntities)));
        }

        [HttpGet]
        [Route("city/{cityId}/entities")]
        public async Task<ActionResult<IEnumerable<VendorWithEntitiesDTO>>> GetManyVendorsWithEntities([FromRoute]string cityId, [FromQuery]bool includeInactive = false)
        {
            if (!ObjectId.TryParse(cityId, out var id))
            {
                return BadRequest($"{nameof(cityId)} is not valid");
            }

            return Ok(await _mediator.Send(new FindVendorsWithEntitiesRequest(id, !includeInactive)));
        }
    }
}
