using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.SDK.VendorEntityDTOs;

namespace Xdl.Internship.Offers.Handlers.VendorEntity
{
    public class InsertVendorEntityRequest : IRequest<VendorEntityDTO>
    {
        public ObjectId VendorId { get; }

        public CreateVendorEntityDTO VendorEntityDTO { get; }

        public InsertVendorEntityRequest(ObjectId vendorId, CreateVendorEntityDTO vendorEntityDTO)
        {
            VendorEntityDTO = vendorEntityDTO;
            VendorId = vendorId;
        }
    }
}
