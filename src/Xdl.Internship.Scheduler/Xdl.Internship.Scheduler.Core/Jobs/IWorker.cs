using System.Threading;
using System.Threading.Tasks;
using Quartz;

namespace Xdl.Internship.Scheduler.Core.Jobs
{
    public interface IWorker
    {
        Task RunAsync(IJobExecutionContext context, CancellationToken cancellationToken = default);
    }
}