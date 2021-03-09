using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Xdl.Internship.Offers.SDK.FavoriteOfferDTOs;

namespace Xdl.Internship.Offers.Handlers.FavoriteOffer
{
    public class AddFavoriteUserOfferRequest : IRequest<FavoriteOfferDTO>
    {
        public AddFavoriteUserOfferRequest(string offerId, string userId)
        {
            OfferId = offerId;
            UserId = userId;
        }

        public string OfferId { get; }

        public string UserId { get; }
    }
}
