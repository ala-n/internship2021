using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.DTOs.Vendor;

namespace Xdl.Internship.Offers.Handlers.Vendor
{
    public class FindAllActiveVendors : IRequest<VendorDTO>
    {
        public ObjectId Id { get; set; }
    }
}
