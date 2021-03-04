using System.Collections.Generic;
using MediatR;
using Xdl.Internship.Offers.SDK.VendorDTOs;

namespace Xdl.Internship.Offers.Handlers.Vendor
{
    public class FindAllVendorsForAdminRequest : IRequest<ICollection<VendorForAdminDTO>>
    {
    }
}
