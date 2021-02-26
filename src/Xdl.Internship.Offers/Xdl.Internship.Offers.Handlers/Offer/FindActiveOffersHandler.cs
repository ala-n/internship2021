using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Offers.DataAccess.Interfaces;

namespace Xdl.Internship.Offers.Handlers.Offer
{
    public class FindActiveOffersHandler : IRequestHandler<FindActiveOffersRequest, ICollection<OfferDTO>>
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IMapper _mapper;

        public FindActiveOffersHandler()
        public Task<ICollection<OfferDTO>> Handle(FindActiveOffersRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
