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
using Xdl.Internship.Offers.SDK.VendorEntityDTOs;

namespace Xdl.Internship.Offers.Handlers.Offer
{
    public class FindOfferByIdWithVendorInfoHandler : IRequestHandler<FindOfferByIdWithVendorInfoRequest, OfferWithAllInfoDTO>
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IVendorEntityRepository _vendorEntityRepository;
        private readonly IVendorRepository _vendorRepository;
        private readonly IMapper _mapper;

        public FindOfferByIdWithVendorInfoHandler(IOfferRepository offerRepository, IVendorEntityRepository vendorEntityRepository, IVendorRepository vendorRepository, IMapper mapper)
        {
            _offerRepository = offerRepository;
            _vendorEntityRepository = vendorEntityRepository;
            _vendorRepository = vendorRepository;
            _mapper = mapper;
        }

        public async Task<OfferWithAllInfoDTO> Handle(FindOfferByIdWithVendorInfoRequest request, CancellationToken cancellationToken)
        {
            var offer = await _offerRepository.FindByIdAsync(request.Id);

            // TO-DO: make in separate handler
            if (request.MetricsView)
            {
                offer.NumberOfViews += 1;
                await _offerRepository.ReplaceOneAsync(offer);
            }

            var result = _mapper.Map<OfferWithAllInfoDTO>(offer);
            if (offer != null && offer.VendorEntitiesId.Count >= 1)
            {
                var entities = await _vendorEntityRepository.FindByIdsAsync(offer.VendorEntitiesId);
                result.VendorEntities = _mapper.Map<ICollection<VendorEntityMainDTO>>(entities);

                if (entities.Count > 0)
                {
                    var vendor = await _vendorRepository.FindByIdAsync(entities.First().VendorId);
                    result = _mapper.Map(vendor, result);
                }
            }

            return result;
        }
    }
}
