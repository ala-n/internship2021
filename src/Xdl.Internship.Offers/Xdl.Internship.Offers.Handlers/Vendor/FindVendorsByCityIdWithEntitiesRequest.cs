using System.Collections.Generic;
using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.SDK.VendorDTOs;

namespace Xdl.Internship.Offers.Handlers.Vendor
{
    public class FindVendorsByCityIdWithEntitiesRequest : IRequest<ICollection<VendorWithEntitiesDTO>>
    {
        public ObjectId CityId { get; }

        public bool OnlyActive { get; }

        public FindVendorsByCityIdWithEntitiesRequest(ObjectId cityId, bool onlyActive)
        {
            CityId = cityId;
            OnlyActive = onlyActive;
        }
    }
}
