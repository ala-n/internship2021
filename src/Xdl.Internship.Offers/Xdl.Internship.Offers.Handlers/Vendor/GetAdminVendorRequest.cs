using System.Collections.Generic;
using MediatR;
using Xdl.Internship.Offers.SDK.VendorDTOs;

namespace Xdl.Internship.Offers.Handlers.Vendor
{
    public class GetAdminVendorRequest : IRequest<ICollection<VendorAdminPanel>>
    {
    }
}