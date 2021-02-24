using System;
using Quartz;

namespace Xdl.Internship.Scheduler.Core.Jobs
{
    public static class JobBuilderExtensions
    {
        public static JobBuilder UsingWorker(this JobBuilder jobBuilder, IWorker worker)
        {
            if (worker == null)
            {
                throw new ArgumentNullException(nameof(worker));
            }

            return jobBuilder.UsingJobData(new JobDataMap { { nameof(DefaultJob.Worker), worker } });
        }
    }
}