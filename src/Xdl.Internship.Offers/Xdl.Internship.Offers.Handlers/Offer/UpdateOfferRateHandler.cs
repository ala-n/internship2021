using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.SDK.OfferDTOs;

namespace Xdl.Internship.Offers.Handlers.Offer
{
    public class UpdateOfferRateHandler : IRequestHandler<UpdateOfferRateRequest, bool>
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IMapper _mapper;

        public UpdateOfferRateHandler(IOfferRepository offerRepository, IMapper mapper)
        {
            _offerRepository = offerRepository ?? throw new System.ArgumentNullException(nameof(offerRepository));
            _mapper = mapper ?? throw new System.ArgumentNullException(nameof(mapper));
        }

        public async Task<bool> Handle(UpdateOfferRateRequest request, CancellationToken cancellationToken)
        {
            var offer = await _offerRepository.FindByIdAsync(request.OfferId);
            if (offer != null)
            {
                offer.Rate = (offer.Rate + request.Rate) / 2;
                await _offerRepository.ReplaceOneAsync(offer);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
