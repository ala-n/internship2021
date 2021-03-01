using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.SDK.OfferDTOs;

namespace Xdl.Internship.Offers.Handlers.Offer
{
    public class FindOfferByIdRequest : IRequest<OfferMainDTO>
    {
        public FindOfferByIdRequest(ObjectId offerId)
        {
            OfferId = offerId;
        }

        public ObjectId OfferId { get; set; }
    }
}
