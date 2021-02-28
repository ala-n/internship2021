using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
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
        public async Task<IEnumerable<VendorDTO>> GetAll()
        {
            return await _mediator.Send(new FindActiveVendorsRequest());
        }

        [HttpGet]
        [Route("city/{cityId}/entities")]
        public async Task<IEnumerable<VendorWithEntitiesDTO>> GetManyWithEntities([FromRoute]string cityId, [FromQuery]bool includeInactive = false)
        {
            return await _mediator.Send(new FindVendorsWithEntitiesRequest(cityId, !includeInactive));
        }
    }
}
