using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.SDK.OfferDTOs;

namespace Xdl.Internship.Offers.Handlers.Offer
{
    public class FindOfferByVendorEntityIdRequest : IRequest<ICollection<OfferMainDTO>>
    {
        public FindOfferByVendorEntityIdRequest(ObjectId vendorEntityId, bool includeInactive)
        {
            VendorEntityId = vendorEntityId;
            IncludeInactive = includeInactive;
        }

        public ObjectId VendorEntityId { get; set; }

        public bool IncludeInactive { get; set; }
    }
}
