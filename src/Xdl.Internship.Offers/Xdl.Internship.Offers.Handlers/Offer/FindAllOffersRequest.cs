using System.Collections.Generic;
using MediatR;
using Xdl.Internship.Offers.SDK.OfferDTOs;

namespace Xdl.Internship.Offers.Handlers.Offer
{
    public class FindAllOffersRequest : IRequest<ICollection<OfferDTO>>
    {
        public bool InlcudeInactive { get; }

        public FindAllOffersRequest(bool includeInactive)
        {
            InlcudeInactive = includeInactive;
        }
    }
}
