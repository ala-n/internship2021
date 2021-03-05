using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.SDK.OfferDTOs;

namespace Xdl.Internship.Offers.Handlers.Offer
{
    public class ReplaceOfferRequest : IRequest<OfferMainDTO>
    {
        public ObjectId Id { get; }

        public UpdateOfferDTO OfferDTO;

        public ReplaceOfferRequest(ObjectId id, UpdateOfferDTO offerDTO)
        {
            Id = id;
            OfferDTO = offerDTO;
        }
    }
}
