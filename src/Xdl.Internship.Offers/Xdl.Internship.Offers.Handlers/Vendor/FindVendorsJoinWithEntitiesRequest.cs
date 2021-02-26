﻿using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.DTOs.VendorDTOs;

namespace Xdl.Internship.Offers.Handlers.Vendor
{
    public class FindVendorsJoinWithEntitiesRequest : IRequest<ICollection<VendorWithEntitiesDTO>>
    {
        // TO-DO after adding CITY model replace string with ObjectId
        // public ObjectId CityId { get; set; }
        public string City { get; set; }

        public bool IncludeEntities { get; set; }

        public bool OnlyActive { get; set; }
    }
}
