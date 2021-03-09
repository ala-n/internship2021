using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.SDK.Identity;
using Xdl.Internship.Offers.SDK.VendorDTOs;

namespace Xdl.Internship.Offers.Handlers.Vendor
{
    public class InsertVendorRequest : IRequest<VendorDTO>
    {
        public CreateVendorDTO VendorDTO { get; }

        public CreateIdentity Identity;

        public InsertVendorRequest(CreateVendorDTO vendorDTO, CreateIdentity identity)
        {
            VendorDTO = vendorDTO;
            Identity = identity;
        }
    }
}
