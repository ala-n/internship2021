using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.SDK.OfferDTOs;

namespace Xdl.Internship.Offers.Handlers.Offer
{
    public class UpdateOfferRateRequest : IRequest<bool>
    {
        public UpdateOfferRateRequest(ObjectId offerId, int rate)
        {
            OfferId = offerId;
            Rate = rate;
        }

        public ObjectId OfferId { get; }

        public int Rate { get; }
    }
}
