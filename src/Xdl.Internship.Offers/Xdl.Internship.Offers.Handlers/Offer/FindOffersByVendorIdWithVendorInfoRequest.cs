using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.SDK.OfferDTOs;

namespace Xdl.Internship.Offers.Handlers.Offer
{
    public class FindOffersByVendorIdWithVendorInfoRequest : IRequest<ICollection<OfferWithVendorInfoDTO>>
    {
        public ObjectId VendorId { get; set; }

        public bool IncludeInactive { get; set; }

        public FindOffersByVendorIdWithVendorInfoRequest(ObjectId vendorId, bool includeInactive)
        {
            VendorId = vendorId;
            IncludeInactive = includeInactive;
        }
    }
}