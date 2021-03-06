using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Xdl.Internship.Core.RabbitMQ;
using Xdl.Internship.Scheduler.Handlers.CheckExpiredOffers;
using Xdl.Internship.Scheduler.Handlers.CheckExpiredOffersFromController;

namespace Xdl.Internship.Scheduler.ServiceHost.Controllers
{
    [ApiController]
    public class CheckExpiredOffersController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMessageSender<MessageDTO> _messageSender;

        public CheckExpiredOffersController(IMessageSender<MessageDTO> messageSender, IMediator mediator)
        {
            _messageSender = messageSender;
            _mediator = mediator;
        }

        [HttpGet]
        [Route("checkExpiredOffersFromRequest")]
        public Task CallRabbit(CancellationToken cancellationToken)
        {
            return _mediator.Send(new CheckExpiredOffersFromControllerRequest(), cancellationToken);
        }
    }
}