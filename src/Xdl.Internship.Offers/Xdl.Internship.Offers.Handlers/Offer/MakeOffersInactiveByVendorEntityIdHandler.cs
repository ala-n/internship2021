using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.Handlers.VendorEntity;

namespace Xdl.Internship.Offers.Handlers.Offer
{
    public class MakeOffersInactiveByVendorEntityIdHandler : INotificationHandler<ReplaceVendorEntityRequest>
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IMapper _mapper;

        public MakeOffersInactiveByVendorEntityIdHandler(IOfferRepository offerRepository, IMapper mapper)
        {
            _offerRepository = offerRepository;
            _mapper = mapper;
        }

        public async Task Handle(ReplaceVendorEntityRequest notification, CancellationToken cancellationToken)
        {
            if (notification.VendorEntityDTO.IsActive)
            {
                return;
            }

            var offers = await _offerRepository.FindByVendorEntityIdAsync(notification.Id);

            foreach (var offer in offers)
            {
                // Deactivate only if offer has one office
                if (offer.VendorEntitiesId.Count == 1)
                {
                    offer.IsActive = false;
                    offer.UpdatedAt = DateTimeOffset.Now;

                    await _offerRepository.ReplaceOneAsync(offer);
                }
            }
        }
    }
}
