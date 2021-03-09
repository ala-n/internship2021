using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.SDK.Identity;
using Xdl.Internship.Offers.SDK.OfferDTOs;

namespace Xdl.Internship.Offers.Handlers.Offer
{
    public class ReplaceOfferRequest : IRequest<OfferMainDTO>
    {
        public ObjectId Id { get; }

        public UpdateOfferDTO OfferDTO;

        public UpdateIdentity Identity;

        public ReplaceOfferRequest(ObjectId id, UpdateOfferDTO offerDTO, UpdateIdentity identity)
        {
            Id = id;
            OfferDTO = offerDTO;
            Identity = identity;
        }
    }
}
