using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.SDK.OfferDTOs;

namespace Xdl.Internship.Offers.Handlers.Offer
{
    public class FindOfferByIdHandler : IRequestHandler<FindOfferByIdRequest, OfferMainDTO>
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IMapper _mapper;

        public FindOfferByIdHandler(IOfferRepository offerRepository, IMapper mapper)
        {
            _offerRepository = offerRepository;
            _mapper = mapper;
        }

        public async Task<OfferMainDTO> Handle(FindOfferByIdRequest request, CancellationToken cancellationToken)
        {
            return _mapper.Map<OfferMainDTO>(await _offerRepository.FindByIdAsync(request.OfferId));
        }
    }
}
