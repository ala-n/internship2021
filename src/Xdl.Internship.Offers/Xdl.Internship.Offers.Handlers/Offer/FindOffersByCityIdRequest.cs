using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Xdl.Internship.Offers.SDK.OfferDTOs;

namespace Xdl.Internship.Offers.Handlers.Offer
{
    public class FindOffersByCityIdRequest : IRequest<ICollection<OfferDTO>>
    {
    }
}
