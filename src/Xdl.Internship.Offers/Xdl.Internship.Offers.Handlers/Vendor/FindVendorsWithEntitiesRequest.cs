using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.SDK.VendorDTOs;

namespace Xdl.Internship.Offers.Handlers.Vendor
{
    public class FindVendorsWithEntitiesRequest : IRequest<ICollection<VendorWithEntitiesDTO>>
    {
        public string CityId { get; }

        public bool OnlyActive { get; }

        public FindVendorsWithEntitiesRequest(string cityId, bool onlyActive)
        {
            CityId = cityId;
            OnlyActive = onlyActive;
        }
    }
}
