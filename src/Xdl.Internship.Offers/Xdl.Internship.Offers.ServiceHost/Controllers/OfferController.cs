using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Xdl.Internship.Offers.DTOs.OfferDTOs;
using Xdl.Internship.Offers.Handlers.Offer;

namespace Xdl.Internship.Offers.ServiceHost.Controllers
{
    [Controller]
    [Route("api/offers")]
    public class OfferController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OfferController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IEnumerable<OfferDTO>> GetAll()
        {
            return await _mediator.Send(new FindActiveOffersRequest());
        }
    }
}
