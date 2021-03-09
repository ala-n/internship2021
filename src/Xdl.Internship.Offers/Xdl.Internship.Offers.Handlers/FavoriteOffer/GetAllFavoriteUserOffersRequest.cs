using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Xdl.Internship.Offers.SDK.FavoriteOfferDTOs;

namespace Xdl.Internship.Offers.Handlers.FavoriteOffer
{
    public class GetAllFavoriteUserOffersRequest : IRequest<ICollection<FavoriteOfferDTO>>
    {
        public GetAllFavoriteUserOffersRequest(string userId)
        {
            UserId = userId;
        }

        public string UserId { get; }
    }
}
