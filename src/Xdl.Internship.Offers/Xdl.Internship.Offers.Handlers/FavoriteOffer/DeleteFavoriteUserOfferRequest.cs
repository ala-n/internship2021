using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace Xdl.Internship.Offers.Handlers.FavoriteOffer
{
    public class DeleteFavoriteUserOfferRequest : IRequest
    {
        public DeleteFavoriteUserOfferRequest(string offerId, string userId)
        {
            OfferId = offerId;
            UserId = userId;
        }

        public string OfferId { get; }

        public string UserId { get; }
    }
}
