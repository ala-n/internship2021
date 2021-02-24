using System;
using System.Threading.Tasks;
using Quartz;

namespace Xdl.Internship.Scheduler.Core.Jobs
{
    public class DefaultJob : IJob
    {
        public IWorker Worker { private get; set; }

        public Task Execute(IJobExecutionContext context)
        {
            // Console.WriteLine("Default JOB");
            return Worker?.RunAsync(context);
        }
    }
}