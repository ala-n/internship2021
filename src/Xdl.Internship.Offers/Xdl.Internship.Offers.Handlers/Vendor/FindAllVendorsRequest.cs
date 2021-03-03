﻿using System.Collections.Generic;
using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.SDK.VendorDTOs;

namespace Xdl.Internship.Offers.Handlers.Vendor
{
    public class FindAllVendorsRequest : IRequest<ICollection<VendorDTO>>
    {
        public bool IncludeInactive { get; }

        public FindAllVendorsRequest(bool includeInactive)
        {
            IncludeInactive = includeInactive;
        }
    }
}
