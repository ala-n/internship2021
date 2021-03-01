using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.SDK.OffersDTOs;

namespace Xdl.Internship.Offers.Handlers.Offer
{
    public class FindOfferByIdRequest : IRequest<ICollection<OfferMainDTO>>
    {
        public FindOfferByIdRequest(ObjectId offerId)
        {
            OfferId = offerId;
        }

        public ObjectId OfferId { get; set; }
    }
}
