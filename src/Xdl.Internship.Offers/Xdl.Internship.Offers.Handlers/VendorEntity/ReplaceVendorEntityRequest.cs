using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.SDK.VendorEntityDTOs;

namespace Xdl.Internship.Offers.Handlers.VendorEntity
{
    public class ReplaceVendorEntityRequest : IRequest<VendorEntityDTO>
    {
        public ObjectId Id { get; }

        public UpdateVendorEntityDTO VendorEntityDTO { get; }

        public ReplaceVendorEntityRequest(ObjectId id, UpdateVendorEntityDTO vendorEntityDTO)
        {
            Id = id;
            VendorEntityDTO = vendorEntityDTO;
        }
    }
}
