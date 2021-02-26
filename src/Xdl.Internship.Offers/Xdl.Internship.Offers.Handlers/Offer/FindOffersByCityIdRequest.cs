using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using Xdl.Internship.Offers.DTOs.OfferDTOs;

namespace Xdl.Internship.Offers.Handlers.Offer
{
    public class FindOffersByCityIdRequest : IRequest<ICollection<OfferDTO>>
    {
    }
}
