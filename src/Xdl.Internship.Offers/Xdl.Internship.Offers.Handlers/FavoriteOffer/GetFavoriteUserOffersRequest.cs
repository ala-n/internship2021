using MediatR;
using Xdl.Internship.Offers.SDK.FavoriteOfferDTOs;

namespace Xdl.Internship.Offers.Handlers.FavoriteOffer
{
    public class GetFavoriteUserOffersRequest : IRequest<FavoriteOfferDTO>
    {
        public GetFavoriteUserOffersRequest(string offerId, string userId)
        {
            OfferId = offerId;
            UserId = userId;
        }

        public string OfferId { get; }

        public string UserId { get; }
    }
}
