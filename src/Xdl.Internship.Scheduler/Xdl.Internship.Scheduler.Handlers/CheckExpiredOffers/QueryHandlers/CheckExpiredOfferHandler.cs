using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
// using Xdl.Internship.Scheduler.Handlers.CheckExpiredOffers.Interfaces;
using Xdl.Internship.Scheduler.Handlers.CheckExpiredOffers.RequestModels;
using Xdl.Internship.Scheduler.Handlers.CheckExpiredOffers.ResponseModels;

namespace Xdl.Internship.Scheduler.Handlers.CheckExpiredOffers.QueryHandlers
{
    public class CheckExpiredOfferHandler : IRequestHandler<CheckExpiredOfferRequestModel, CheckExpiredOfferResponseModel>
    {
        public Task<CheckExpiredOfferResponseModel> Handle(CheckExpiredOfferRequestModel request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
