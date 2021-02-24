using MediatR;
using MongoDB.Bson;
using System.Threading;
using System.Threading.Tasks;
using Xdl.Internship.Offers.DataAccess.Repositories;
using Xdl.Internship.Offers.DTOs.Vendor;

namespace Xdl.Internship.Offers.Handlers.Vendor
{
    public class FindAllActiveVendorsHandler : IRequestHandler<FindAllActiveVendors, VendorDTO>
    {

        public FindAllActiveVendorsHandler(VendorRepository vendorRepository)
        {

        }

        public Task<VendorDTO> Handle(FindAllActiveVendors request, CancellationToken cancellationToken)
        {

        }
    }
}
