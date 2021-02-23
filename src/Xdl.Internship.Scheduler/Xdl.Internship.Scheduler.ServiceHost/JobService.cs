using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Quartz;
using Xdl.Internship.Scheduler.Core.Jobs;

namespace Xdl.Internship.Scheduler.ServiceHost
{
    public class JobService : IHostedService
    {
        private readonly ISchedulerFactory _schedulerFactory;
        private readonly IEnumerable<IJobSetup> _jobSetups;

        public JobService(ISchedulerFactory schedulerFactory, IEnumerable<IJobSetup> jobSetups)
        {
            _schedulerFactory = schedulerFactory;
            _jobSetups = jobSetups;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            IScheduler scheduler = await _schedulerFactory.GetScheduler(cancellationToken);

            foreach (IJobSetup jobSetup in _jobSetups)
            {
                await jobSetup.SetupJobAsync(scheduler, cancellationToken);
            }

            await scheduler.Start(cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            IScheduler scheduler = await _schedulerFactory.GetScheduler(cancellationToken);

            await scheduler.Shutdown(false, cancellationToken);
        }
    }
}