using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MongoDB.Bson;

namespace Xdl.Internship.Offers.Handlers.Vendor
{
    public class FindVendorsJoinWithEntitiesRequest : IRequest<ICollection<VendorWithEntitiesDTO>>
    {
        public ObjectId CityId { get; set; }

        public bool OnlyActive { get; set; } = true;
    }
}
