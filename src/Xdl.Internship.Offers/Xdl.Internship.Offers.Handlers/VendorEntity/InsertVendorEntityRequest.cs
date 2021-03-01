using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.SDK.VendorEntityDTOs;

namespace Xdl.Internship.Offers.Handlers.VendorEntity
{
    public class InsertVendorEntityRequest : IRequest<VendorEntityDTO>
    {
        public ObjectId VendorId { get; }

        public CreateVendorEntityDTO VendorEntityDTO { get; }

        public InsertVendorEntityRequest(CreateVendorEntityDTO vendorEntityDTO, ObjectId vendorId)
        {
            VendorEntityDTO = vendorEntityDTO;
            VendorId = vendorId;
        }
    }
}
