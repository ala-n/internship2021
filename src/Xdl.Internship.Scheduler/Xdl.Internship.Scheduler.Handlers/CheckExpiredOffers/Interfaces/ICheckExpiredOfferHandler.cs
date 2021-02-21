using System;
using Xdl.Internship.Scheduler.Handlers.CheckExpiredOffers.RequestModels;
using Xdl.Internship.Scheduler.Handlers.CheckExpiredOffers.ResponseModels;

namespace Xdl.Internship.Scheduler.Handlers.CheckExpiredOffers.Interfaces
{
    public interface ICheckExpiredOfferHandler
    {
        CheckExpiredOfferResponseModel CheckOffer(CheckExpiredOfferRequestModel requestModel);
    }
}
