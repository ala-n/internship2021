using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Xdl.Internship.Scheduler.Handlers.CheckExpiredOffersFromController
{
    public class CheckExpiredOffersFromControllerHandler : IRequestHandler<CheckExpiredOffersFromControllerRequest, bool>
    {
        public async Task<bool> Handle(CheckExpiredOffersFromControllerRequest request, CancellationToken cancellationToken)
        {
            // Send message to rabbit

            return true;
        }
    }
}
