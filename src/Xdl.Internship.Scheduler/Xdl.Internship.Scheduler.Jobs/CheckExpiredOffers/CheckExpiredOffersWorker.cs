using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;
using Quartz;
using Xdl.Internship.Scheduler.Core.Jobs;
using Xdl.Internship.Scheduler.Handlers.CheckExpiredOffers;

namespace Xdl.Internship.Scheduler.Jobs.CheckExpiredOffers
{
    public class CheckExpiredOffersWorker : IWorker
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CheckExpiredOffersWorker> _logger;

        public CheckExpiredOffersWorker(IMediator mediator, ILogger<CheckExpiredOffersWorker> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(_mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(_logger));
        }

        public Task RunAsync(IJobExecutionContext context, CancellationToken cancellationToken = default)
        {
             Console.WriteLine("Job execute");

             return _mediator.Send(new CheckExpiredOffersRequest(), cancellationToken);
        }
    }
}
