using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Xdl.Internship.Offers.DTOs.VendorDTOs;
using Xdl.Internship.Offers.Handlers.Vendor;

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
        [Route("/city")]
        public async Task<IEnumerable<VendorWithEntitiesDTO>> GetManyWithEntities(string? cityId, bool? onlyActive)
        {
            return await _mediator.Send(new FindVendorsJoinWithEntitiesRequest() { });
        }
    }
}
