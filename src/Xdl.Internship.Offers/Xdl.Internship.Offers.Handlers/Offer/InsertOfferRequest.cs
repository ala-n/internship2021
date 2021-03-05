using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.SDK.OfferDTOs;

namespace Xdl.Internship.Offers.Handlers.Offer
{
    public class InsertOfferRequest : IRequest<OfferMainDTO>
    {
        public CreateOfferDTO OfferDTO;

        public InsertOfferRequest(CreateOfferDTO offerDTO)
        {
            OfferDTO = offerDTO;
        }
    }
}
