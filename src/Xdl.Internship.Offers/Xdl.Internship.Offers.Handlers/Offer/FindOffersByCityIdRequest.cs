﻿using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.SDK.OfferDTOs;

namespace Xdl.Internship.Offers.Handlers.Offer
{
    public class FindOffersByCityIdRequest : IRequest<ICollection<OfferForListDTO>>
    {
        public FindOffersByCityIdRequest(string cityId)
        {
        }

        public ObjectId CityId { get; set; }
    }
}
