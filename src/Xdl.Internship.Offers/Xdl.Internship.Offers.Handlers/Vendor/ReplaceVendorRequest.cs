using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.SDK.Identity;
using Xdl.Internship.Offers.SDK.VendorDTOs;

namespace Xdl.Internship.Offers.Handlers.Vendor
{
    public class ReplaceVendorRequest : INotification
    {
        public ObjectId Id { get; }

        public UpdateVendorDTO VendorDTO;

        public UpdateIdentity Identity;

        public ReplaceVendorRequest(ObjectId id, UpdateVendorDTO vendorDTO, UpdateIdentity identity)
        {
            Id = id;
            VendorDTO = vendorDTO;
            Identity = identity;
        }
    }
}
