using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.SDK.OfferDTOs;

namespace Xdl.Internship.Offers.Handlers.Offer
{
    public class FindAllOffersWithVendorInfoRequest : IRequest<ICollection<OfferWithVendorNameDTO>>
    {
        public bool IncludeInactive { get; set; }

        public FindAllOffersWithVendorInfoRequest(bool includeInactive)
        {
            IncludeInactive = includeInactive;
        }
    }
}
