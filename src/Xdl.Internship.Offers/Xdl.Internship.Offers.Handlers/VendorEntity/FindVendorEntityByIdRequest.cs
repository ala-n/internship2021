using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.SDK.VendorEntityDTOs;

namespace Xdl.Internship.Offers.Handlers.VendorEntity
{
    public class FindVendorEntityByIdRequest : IRequest<VendorEntityWithVendorNameDTO>
    {
        public ObjectId Id { get; }

        public FindVendorEntityByIdRequest(ObjectId id)
        {
            Id = id;
        }
    }
}
