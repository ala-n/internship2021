using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.DataAccess.Repositories;
using Xdl.Internship.Offers.SDK.OfferDTOs;

namespace Xdl.Internship.Offers.Handlers.Offer
{
    public class FindAllOffersHandler : IRequestHandler<FindAllOffersRequest, ICollection<OfferDTO>>
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IMapper _mapper;

        public FindAllOffersHandler(OfferRepository offerRepository, IMapper mapper)
        {
            _offerRepository = offerRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<OfferDTO>> Handle(FindAllOffersRequest request, CancellationToken cancellationToken)
        {
            var offers = await _offerRepository.FindAsync(request.InlcudeInactive);
            var offerDTO = new List<OfferDTO> { };

            foreach (var offer in offers)
            {
                offerDTO.Add(_mapper.Map<OfferDTO>(offer));
            }

            return offerDTO;
        }
    }
}
