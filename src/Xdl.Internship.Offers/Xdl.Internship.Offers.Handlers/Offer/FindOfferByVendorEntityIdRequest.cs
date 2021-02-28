using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.SDK.OffersDTOs;

namespace Xdl.Internship.Offers.Handlers.Offer
{
    public class FindOfferByVendorEntityIdRequest : IRequest<ICollection<OfferMainDTO>>
    {
        public FindOfferByVendorEntityIdRequest(ObjectId vendorEntityId)
        {
            VendorEntityId = vendorEntityId;
        }

        public ObjectId VendorEntityId { get; set; }
    }
}
