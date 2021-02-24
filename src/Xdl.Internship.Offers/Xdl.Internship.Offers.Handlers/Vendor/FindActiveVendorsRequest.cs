using System.Collections.Generic;
using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.DTOs.VendorDTOs;

namespace Xdl.Internship.Offers.Handlers.Vendor
{
    public class FindActiveVendorsRequest : IRequest<ICollection<VendorDTO>>
    {
    }
}
