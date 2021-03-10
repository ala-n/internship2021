using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.SDK.Identity;
using Xdl.Internship.Offers.SDK.VendorEntityDTOs;

namespace Xdl.Internship.Offers.Handlers.VendorEntity
{
    public class InsertVendorEntityRequest : IRequest<VendorEntityDTO>
    {
        public ObjectId VendorId { get; }

        public CreateVendorEntityDTO VendorEntityDTO { get; }

        public CreateIdentity Identity;

        public InsertVendorEntityRequest(ObjectId vendorId, CreateVendorEntityDTO vendorEntityDTO, CreateIdentity identity)
        {
            VendorEntityDTO = vendorEntityDTO;
            VendorId = vendorId;
            Identity = identity;
        }
    }
}
