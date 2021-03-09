using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.SDK.OfferDTOs;

namespace Xdl.Internship.Offers.Handlers.Offer
{
    public class ReplaceOfferHandler : IRequestHandler<ReplaceOfferRequest, OfferMainDTO>
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IMapper _mapper;

        public ReplaceOfferHandler(IOfferRepository offerRepository, IMapper mapper)
        {
            _offerRepository = offerRepository;
            _mapper = mapper;
        }

        public async Task<OfferMainDTO> Handle(ReplaceOfferRequest request, CancellationToken cancellationToken)
        {
            var oldOffer = await _offerRepository.FindByIdAsync(request.Id);

            var offer = _mapper.Map(request.OfferDTO, oldOffer);
            offer = _mapper.Map(request.Identity, offer);

            await _offerRepository.ReplaceOneAsync(offer);

            return _mapper.Map<OfferMainDTO>(offer);
        }
    }
}
