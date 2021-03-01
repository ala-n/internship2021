using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.SDK.VendorDTOs;

namespace Xdl.Internship.Offers.Handlers.Vendor
{
    public class FindVendorByIdRequest : IRequest<VendorWithEntitiesDTO>
    {
        public ObjectId Id { get; }

        public bool IncludeEntites { get; }

        public FindVendorByIdRequest(ObjectId id, bool includeEntities)
        {
            Id = id;
            IncludeEntites = includeEntities;
        }
    }
}
