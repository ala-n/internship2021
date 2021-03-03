using System.Collections.Generic;
using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.SDK.VendorDTOs;

namespace Xdl.Internship.Offers.Handlers.Vendor
{
    public class FindActiveVendorsRequest : IRequest<ICollection<VendorDTO>>
    {
        public bool IncludeInactive { get; }

        public FindActiveVendorsRequest(bool includeInactive)
        {
            IncludeInactive = includeInactive;
        }
    }
}
