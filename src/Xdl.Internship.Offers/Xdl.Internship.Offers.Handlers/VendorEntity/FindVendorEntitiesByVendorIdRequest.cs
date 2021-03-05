using System.Collections.Generic;
using MediatR;
using Xdl.Internship.Offers.SDK.VendorEntityDTOs;

namespace Xdl.Internship.Offers.Handlers.VendorEntity
{
    public class FindVendorEntitiesByVendorIdRequest : IRequest<ICollection<VendorEntityForAdminDTO>>
    {
    }
}
