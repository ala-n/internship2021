using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.SDK.VendorDTOs;

namespace Xdl.Internship.Offers.Handlers.Vendor
{
    public class FindVendorByIdForAdminRequest : IRequest<VendorMainDTO>
    {
        public ObjectId Id { get; }

        public FindVendorByIdForAdminRequest(ObjectId id)
        {
            Id = id;
        }
    }
}
