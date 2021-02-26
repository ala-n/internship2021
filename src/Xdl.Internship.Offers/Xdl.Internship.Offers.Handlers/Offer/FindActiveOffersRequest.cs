using System.Collections.Generic;
using MediatR;

namespace Xdl.Internship.Offers.Handlers.Offer
{
    public class FindActiveOffersRequest : IRequest<ICollection<OfferDTO>>
    {
    }
}
