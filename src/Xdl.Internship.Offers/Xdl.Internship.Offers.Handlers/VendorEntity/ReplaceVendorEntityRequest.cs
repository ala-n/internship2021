using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.SDK.Identity;
using Xdl.Internship.Offers.SDK.VendorEntityDTOs;

namespace Xdl.Internship.Offers.Handlers.VendorEntity
{
    public class ReplaceVendorEntityRequest : INotification
    {
        public ObjectId Id { get; }

        public UpdateVendorEntityDTO VendorEntityDTO { get; }

        public UpdateIdentity Identity;

        public ReplaceVendorEntityRequest(ObjectId id, UpdateVendorEntityDTO vendorEntityDTO, UpdateIdentity identity)
        {
            Id = id;
            VendorEntityDTO = vendorEntityDTO;
            Identity = identity;
        }
    }
}
