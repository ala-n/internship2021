using System.Collections.Generic;
using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.SDK.VendorEntityDTOs;

namespace Xdl.Internship.Offers.Handlers.VendorEntity
{
    public class FindVendorEntitiesByVendorIdRequest : IRequest<ICollection<VendorEntityDTO>>
    {
        public ObjectId VendorId { get; }

        public bool IncludeInactive { get; }

        public FindVendorEntitiesByVendorIdRequest(ObjectId vendorId, bool includeInactive)
        {
            VendorId = vendorId;
            IncludeInactive = includeInactive;
        }
    }
}
