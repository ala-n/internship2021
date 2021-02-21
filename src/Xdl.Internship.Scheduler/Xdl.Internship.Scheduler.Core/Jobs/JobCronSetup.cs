using System;
using System.Threading;
using System.Threading.Tasks;
using Quartz;

namespace Xdl.Internship.Scheduler.Core.Jobs
{
    public abstract class JobCronSetup : IJobSetup
    {
        private readonly IWorker _worker;
        private readonly string _cronExpression;
        private readonly Type _defaultJobType;

        protected JobCronSetup(IWorker worker, string cronExpression)
        {
            _worker = worker ?? throw new ArgumentNullException(nameof(worker));
            _cronExpression = cronExpression ?? throw new ArgumentNullException(nameof(cronExpression));

            _defaultJobType = typeof(DefaultJob);
        }

        public Task SetupJobAsync(IScheduler scheduler, CancellationToken cancellationToken = default)
        {
            var job = CreateJob();
            var trigger = CreateTrigger();

            return scheduler.ScheduleJob(job, trigger, cancellationToken);
        }

        protected virtual Type GetJobType()
        {
            return _defaultJobType;
        }

        private ITrigger CreateTrigger()
        {
            var workerType = _worker.GetType();
            return TriggerBuilder
                .Create()
                .WithIdentity($"{workerType.FullName}.trigger")
                .WithCronSchedule(_cronExpression)
                .WithDescription($"JobType: {workerType.FullName}; Cron Expr: {_cronExpression}")
                .Build();
        }

        private IJobDetail CreateJob()
        {
            var workerType = _worker.GetType();
            return JobBuilder
                .Create(GetJobType())
                .WithIdentity(workerType.FullName)
                .UsingWorker(_worker)
                .Build();
        }
    }
}