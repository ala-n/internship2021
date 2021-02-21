using Quartz;

namespace Xdl.Internship.Scheduler.Core.Jobs
{
    [DisallowConcurrentExecution]
    public class NonConcurrentJob : DefaultJob
    {
    }
}