using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Xdl.Internship.Scheduler.Handlers.CheckExpiredOffersFromController;

namespace Xdl.Internship.Scheduler.ServiceHost.Controllers
{
    [ApiController]
    public class CheckExpiredOffersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CheckExpiredOffersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("checkExpiredOffers")]
        public Task RunAsync(CancellationToken cancellationToken = default)
        {
            return _mediator.Send(new CheckExpiredOffersFromControllerRequest(), cancellationToken);
        }
    }
}
