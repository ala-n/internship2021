using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.DataAccess.Repositories;
using Xdl.Internship.Offers.DTOs.OfferDTOs;

namespace Xdl.Internship.Offers.Handlers.Offer
{
    public class FindActiveOffersHandler : IRequestHandler<FindActiveOffersRequest, ICollection<OfferDTO>>
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IMapper _mapper;

        public FindActiveOffersHandler(OfferRepository offerRepository, IMapper mapper)
        {
            _offerRepository = offerRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<OfferDTO>> Handle(FindActiveOffersRequest request, CancellationToken cancellationToken)
        {
            var offers = await _offerRepository.FindActiveAsync();
            var offerDTO = new List<OfferDTO> { };

            foreach (var offer in offers)
            {
                offerDTO.Add(_mapper.Map<OfferDTO>(offer));
            }

            return offerDTO;
        }
    }
}
