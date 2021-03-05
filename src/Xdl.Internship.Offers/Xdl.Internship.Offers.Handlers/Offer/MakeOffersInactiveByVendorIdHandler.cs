using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.Handlers.Vendor;

namespace Xdl.Internship.Offers.Handlers.Offer
{
    public class MakeOffersInactiveByVendorIdHandler : INotificationHandler<ReplaceVendorRequest>
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IVendorEntityRepository _vendorEntityRepository;
        private readonly IMapper _mapper;

        public MakeOffersInactiveByVendorIdHandler(IOfferRepository offerRepository, IVendorEntityRepository vendorEntityRepository, IMapper mapper)
        {
            _offerRepository = offerRepository;
            _vendorEntityRepository = vendorEntityRepository;
            _mapper = mapper;
        }

        public async Task Handle(ReplaceVendorRequest request, CancellationToken cancellationToken)
        {
            if (request.VendorDTO.IsActive)
            {
                return;
            }

            var entities = await _vendorEntityRepository.FindByVendorIdAsync(request.Id, false);

            foreach (var entity in entities)
            {
                var offers = await _offerRepository.FindByVendorEntityIdAsync(entity.Id);
                foreach (var offer in offers)
                {
                    offer.IsActive = false;
                    offer.UpdatedAt = DateTimeOffset.Now;

                    await _offerRepository.ReplaceOneAsync(offer);
                }
            }
        }
    }
}
