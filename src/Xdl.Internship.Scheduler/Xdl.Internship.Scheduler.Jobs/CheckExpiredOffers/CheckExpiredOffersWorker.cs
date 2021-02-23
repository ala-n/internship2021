using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Quartz;
using Xdl.Internship.Scheduler.Core.Jobs;
using System;
using MediatR;
using Xdl.Internship.Scheduler.Handlers.CheckExpiredOffers;

namespace Xdl.Internship.Scheduler.Jobs.CheckExpiredOffers
{
    public class CheckExpiredOffersWorker : IWorker
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CheckExpiredOffersWorker> _logger;

        public CheckExpiredOffersWorker(IMediator mediator, ILogger<CheckExpiredOffersWorker> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public Task RunAsync(IJobExecutionContext context, CancellationToken cancellationToken = default)
        {
            // Console.WriteLine("Job execute");
            return _mediator.Publish(new CheckExpiredOffersRequest(), cancellationToken);
        }
    }
}
