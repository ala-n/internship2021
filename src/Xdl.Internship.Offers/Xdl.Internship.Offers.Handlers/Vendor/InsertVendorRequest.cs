using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.SDK.VendorDTOs;

namespace Xdl.Internship.Offers.Handlers.Vendor
{
    public class InsertVendorRequest : IRequest<VendorForAdminDTO>
    {
        public CreateVendorDTO VendorDTO { get; }

        public InsertVendorRequest(CreateVendorDTO vendorDTO)
        {
            VendorDTO = vendorDTO;
        }
    }
}
