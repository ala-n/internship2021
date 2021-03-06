using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.SDK.OfferDTOs;

namespace Xdl.Internship.Offers.Handlers.Offer
{
    public class FindOfferByIdWithVendorInfoRequest : IRequest<OfferWithVendorInfoDTO>
    {
        public ObjectId Id { get; set; }

        public FindOfferByIdWithVendorInfoRequest(ObjectId id)
        {
            Id = id;
        }
    }
}
