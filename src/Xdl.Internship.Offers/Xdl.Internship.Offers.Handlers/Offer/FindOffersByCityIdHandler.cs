using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Xdl.Internship.Offers.DTOs.OfferDTOs;

namespace Xdl.Internship.Offers.Handlers.Offer
{
    public class FindOffersByCityIdHandler : IRequestHandler<FindOffersByCityIdRequest, ICollection<OfferDTO>>
    {
        public Task<ICollection<OfferDTO>> Handle(FindOffersByCityIdRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
