﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
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
        private readonly IMapper _mapper;

        public VendorController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VendorDTO>>> GetAllVendors([FromQuery]bool includeInactive = false)
        {
            return Ok(await _mediator.Send(new FindAllVendorsRequest(includeInactive)));
        }

        [HttpGet]
        [Route("{vendorId}")]
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

            return Ok(await _mediator.Send(new FindVendorsWithEntitiesRequest(id, !includeInactive)));
        }

        [HttpGet]
        [Route("admin")]
        public async Task<ActionResult<ICollection<VendorForAdminDTO>>> GetAllVendorsForAdmin()
        {
            return Ok(await _mediator.Send(new FindAllVendorsForAdminRequest()));
        }

        [HttpGet]
        [Route("${id}/admin")]
        public async Task<ActionResult<VendorMainDTO>> GetVendorByIdForAdmin([FromRoute] string id)
        {
            if (!ObjectId.TryParse(id, out var parsedId))
            {
                return BadRequest($"{nameof(id)} is not valid");
            }

            return Ok(await _mediator.Send(new FindVendorByIdForAdminRequest(parsedId)));
        }

        [HttpPost]
        public async Task<ActionResult<VendorDTO>> CreateVendor([FromBody] CreateVendorDTO vendorDTO)
        {
            return Ok(await _mediator.Send(new InsertVendorRequest(vendorDTO)));
        }
    }
}
