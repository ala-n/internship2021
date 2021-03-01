using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.SDK.OfferDTOs;

namespace Xdl.Internship.Offers.Handlers.Offer
{
    public class FindOffersByVendorIdRequest : IRequest<ICollection<OfferMainDTO>>
    {
        public FindOffersByVendorIdRequest(ObjectId vendorId)
        {
            VendorId = vendorId;
        }

        public ObjectId VendorId { get; set; }
    }
}
