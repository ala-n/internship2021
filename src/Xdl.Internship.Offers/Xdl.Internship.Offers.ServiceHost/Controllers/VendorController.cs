using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.Handlers.Vendor;
using Xdl.Internship.Offers.Models;
using Xdl.Internship.Offers.SDK.VendorDTOs;

namespace Xdl.Internship.Offers.ServiceHost.Controllers
{
    [Controller]
    [Route("api/vendors")]
    public class VendorController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IVendorRepository _vendorRepository;
        private readonly IMapper _mapper;

        public VendorController(IMediator mediator, IVendorRepository vendorRepository, IMapper mapper)
        {
            _mediator = mediator;
            _vendorRepository = vendorRepository;
            _mapper = mapper;
        }

        [HttpGet("allActive")]
        public async Task<ActionResult<IEnumerable<VendorDTO>>> GetAllActive()
        {
            return Ok(await _mediator.Send(new FindActiveVendorsRequest()));
        }

        [HttpGet]
        [Route("{vendorId}")]
        public async Task<ActionResult<VendorWithEntitiesDTO>> GetByIdWithEntities([FromRoute] string vendorId, [FromQuery] bool includeEntities = false)
        {
            if (!ObjectId.TryParse(vendorId, out var id))
            {
                return BadRequest($"{nameof(vendorId)} is not valid");
            }

            return Ok(await _mediator.Send(new FindVendorByIdRequest(id, includeEntities)));
        }

        [HttpGet]
        [Route("city/{cityId}/entities")]
        public async Task<ActionResult<IEnumerable<VendorWithEntitiesDTO>>> GetManyWithEntities([FromRoute]string cityId, [FromQuery]bool includeInactive = false)
        {
            if (!ObjectId.TryParse(cityId, out var id))
            {
                return BadRequest($"{nameof(cityId)} is not valid");
            }

            return Ok(await _mediator.Send(new FindVendorsWithEntitiesRequest(id, !includeInactive)));
        }

        [HttpPost("add")]
        public async Task<ActionResult<Vendor>> AddVendor([FromBody] VendorCreate vendor)
        {
            if (vendor == null)
            {
                return BadRequest();
            }

            return Ok(await _mediator.Send(new AddVendorRequest(vendor.Name, vendor.Title, vendor.Website, vendor.Description, vendor.IsActive, vendor.CreatedBy)));
        }

        [HttpGet("allAdmin")]
        public async Task<ActionResult<ICollection<VendorAdminPanel>>> GetAdminVendor()
        {
            return Ok(await _mediator.Send(new GetAdminVendorRequest()));
        }

        [HttpGet("/api/get/{id}")]
        public async Task<ActionResult<VendorByIdAdminPanel>> GetAdminVendorById(string id)
        {
            var objId = new ObjectId(id);
            var data = await _vendorRepository.FindAdminVendorById(objId);
            return Ok(_mapper.Map<VendorByIdAdminPanel>(data));
        }
    }
}
