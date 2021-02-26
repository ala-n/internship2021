using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Xdl.Internship.Scheduler.Handlers.CheckExpiredOffers
{
    public class CheckExpiredOffersHandler : IRequestHandler<CheckExpiredOffersRequest, bool>
    {
        public async Task<bool> Handle(CheckExpiredOffersRequest request, CancellationToken cancellationToken)
        {
            // Send command in Rabbit Quee
            Console.WriteLine("Message from Handler");
            return true;
        }
    }
}
