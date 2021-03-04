using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.SDK.VendorDTOs;

namespace Xdl.Internship.Offers.Handlers.Vendor
{
    public class DeleteVendorRequest : IRequest
    {
        public ObjectId Id { get; }

        public DeleteVendorRequest(ObjectId id)
        {
            Id = id;
        }
    }
}
