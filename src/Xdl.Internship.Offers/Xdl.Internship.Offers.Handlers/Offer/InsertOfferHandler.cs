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
    public class InsertOfferHandler : IRequestHandler<InsertOfferRequest, OfferMainDTO>
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IVendorEntityRepository _vendorEntityRepository;
        private readonly IMapper _mapper;

        public InsertOfferHandler(IOfferRepository offerRepository, IVendorEntityRepository vendorEntityRepository, IMapper mapper)
        {
            _offerRepository = offerRepository;
            _vendorEntityRepository = vendorEntityRepository;
            _mapper = mapper;
        }

        public async Task<OfferMainDTO> Handle(InsertOfferRequest request, CancellationToken cancellationToken)
        {
            var offer = _mapper.Map<Models.Offer>(request.OfferDTO);
            offer = _mapper.Map(request.Identity, offer);

            // TO-DO: validate EntitiesID and TagsId, through foreach?
            await _offerRepository.InsertOneAsync(offer);

            return _mapper.Map<OfferMainDTO>(await _offerRepository.FindByIdAsync(offer.Id));
        }
    }
}
