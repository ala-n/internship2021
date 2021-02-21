using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Quartz;
using Xdl.Internship.Scheduler.Core.Jobs;
using System;

namespace Xdl.Internship.Scheduler.Jobs.CheckExpiredOffers
{
    public class CheckExpiredOffersWorker : IWorker
    {
        private readonly ILogger<CheckExpiredOffersWorker> _logger;

        public CheckExpiredOffersWorker(ILogger<CheckExpiredOffersWorker> logger)
        {
            _logger = logger;
        }

        public Task RunAsync(IJobExecutionContext context, CancellationToken cancellationToken = default)
        {
            // Console.WriteLine("Job execute");
            return Task.CompletedTask;
        }
    }
}
