using System.Collections.Generic;
using MediatR;
using Xdl.Internship.Offers.SDK.OfferDTOs;

namespace Xdl.Internship.Offers.Handlers.Offer
{
    public class FindActiveOffersRequest : IRequest<ICollection<OfferForListDTO>>
    {
    }
}
