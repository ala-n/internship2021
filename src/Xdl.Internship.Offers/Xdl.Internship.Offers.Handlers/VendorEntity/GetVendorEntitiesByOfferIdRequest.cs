using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.SDK.VendorEntityDTOs;

namespace Xdl.Internship.Offers.Handlers.VendorEntity
{
    public class GetVendorEntitiesByOfferIdRequest : IRequest<ICollection<VendorEntityMainDTO>>
    {
        public ObjectId OfferId { get; set; }

        public GetVendorEntitiesByOfferIdRequest(ObjectId offerId)
        {
            OfferId = offerId;
        }
    }
}
