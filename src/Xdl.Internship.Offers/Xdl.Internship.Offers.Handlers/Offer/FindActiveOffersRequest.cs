using System.Collections.Generic;
using MediatR;
using Xdl.Internship.Offers.DTOs.OfferDTOs;

namespace Xdl.Internship.Offers.Handlers.Offer
{
    public class FindActiveOffersRequest : IRequest<ICollection<OfferDTO>>
    {
    }
}
