using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.SDK.VendorEntityDTOs;

namespace Xdl.Internship.Offers.Handlers.VendorEntity
{
    public class DeleteVendorEntityRequest : IRequest
    {
        public ObjectId Id { get; }

        public DeleteVendorEntityRequest(ObjectId id)
        {
            Id = id;
        }
    }
}
