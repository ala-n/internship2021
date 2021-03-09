using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.SDK.Identity;
using Xdl.Internship.Offers.SDK.OfferDTOs;

namespace Xdl.Internship.Offers.Handlers.Offer
{
    public class InsertOfferRequest : IRequest<OfferMainDTO>
    {
        public CreateOfferDTO OfferDTO { get; }

        public CreateIdentity Identity { get; }

        public InsertOfferRequest(CreateOfferDTO offerDTO, CreateIdentity identity)
        {
            OfferDTO = offerDTO;
            Identity = identity;
        }
    }
}
