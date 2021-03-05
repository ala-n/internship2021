using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.SDK.VendorDTOs;

namespace Xdl.Internship.Offers.Handlers.Offer
{
    public class GetVendorInfoByOfferIdRequest : IRequest<VendorInfoForOfferDTO>
    {
        public ObjectId OfferId { get; set; }

        public GetVendorInfoByOfferIdRequest(ObjectId offerId)
        {
            OfferId = offerId;
        }
    }
}