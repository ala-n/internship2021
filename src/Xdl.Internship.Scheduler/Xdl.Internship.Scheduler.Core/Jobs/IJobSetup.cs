using System.Threading;
using System.Threading.Tasks;
using Quartz;

namespace Xdl.Internship.Scheduler.Core.Jobs
{
    public interface IJobSetup
    {
        Task SetupJobAsync(IScheduler scheduler, CancellationToken cancellationToken = default);
    }
}