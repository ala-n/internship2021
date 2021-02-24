using System;
using Xdl.Internship.Scheduler.Core.Jobs;

namespace Xdl.Internship.Scheduler.Jobs.CheckExpiredOffers
{
    public class CheckExpiredOffersJobSetup : JobCronSetup
    {
        private readonly Type _jobType;

        public CheckExpiredOffersJobSetup(CheckExpiredOffersWorker worker)
            : base(worker, "0/10 * * * * ?")
        {
            _jobType = typeof(NonConcurrentJob);
        }

        protected override Type GetJobType()
        {
            return _jobType;
        }
    }
}
