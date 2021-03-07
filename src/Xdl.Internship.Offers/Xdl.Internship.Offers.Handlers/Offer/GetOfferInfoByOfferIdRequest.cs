using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.SDK.OfferDTOs;

namespace Xdl.Internship.Offers.Handlers.Offer
{
    public class GetOfferInfoByOfferIdRequest : IRequest<OfferWithAllInfoDTO>
    {
        public GetOfferInfoByOfferIdRequest(ObjectId offerId)
        {
            OfferId = offerId;
        }

        public ObjectId OfferId { get; set; }
    }
}
