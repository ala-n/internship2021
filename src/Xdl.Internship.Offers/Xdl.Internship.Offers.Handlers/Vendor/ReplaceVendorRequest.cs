using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.SDK.VendorDTOs;

namespace Xdl.Internship.Offers.Handlers.Vendor
{
    public class ReplaceVendorRequest : INotification
    {
        public ObjectId Id { get; }

        public UpdateVendorDTO VendorDTO;

        public ReplaceVendorRequest(ObjectId id, UpdateVendorDTO vendorDTO)
        {
            Id = id;

            VendorDTO = vendorDTO;
        }
    }
}
