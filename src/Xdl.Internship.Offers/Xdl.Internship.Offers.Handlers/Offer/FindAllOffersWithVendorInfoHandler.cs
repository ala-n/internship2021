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
    public class FindAllOffersWithVendorInfoHandler : IRequestHandler<FindAllOffersWithVendorInfoRequest, ICollection<OfferWithVendorInfoDTO>>
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IVendorEntityRepository _vendorEntityRepository;
        private readonly IVendorRepository _vendorRepository;
        private readonly IMapper _mapper;

        public FindAllOffersWithVendorInfoHandler(IOfferRepository offerRepository, IVendorEntityRepository vendorEntityRepository, IVendorRepository vendorRepository, IMapper mapper)
        {
            _offerRepository = offerRepository;
            _vendorEntityRepository = vendorEntityRepository;
            _vendorRepository = vendorRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<OfferWithVendorInfoDTO>> Handle(FindAllOffersWithVendorInfoRequest request, CancellationToken cancellationToken)
        {
            var offers = await _offerRepository.FindAsync(request.IncludeInactive);
            var entityIds = offers.Select(o => o.VendorEntitiesId).SelectMany(e => e).Distinct().ToList();

            var entities = await _vendorEntityRepository.FindByIdsAsync(entityIds);
            var vendorIds = entities.Select(e => e.VendorId).Distinct().ToList();
            var entitiesById = entities.ToDictionary(e => e.Id);

            var vendors = await _vendorRepository.FindByIdsAsync(vendorIds);
            var vendorById = vendors.ToDictionary(e => e.Id);

            ICollection<OfferWithVendorInfoDTO> result = new List<OfferWithVendorInfoDTO>();
            foreach (var offer in offers)
            {
                var offerDTO = _mapper.Map<OfferWithVendorInfoDTO>(offer);
                if (entitiesById.TryGetValue(offer.VendorEntitiesId.FirstOrDefault(), out var entity))
                {
                    if (vendorById.TryGetValue(entity.VendorId, out var vendor))
                    {
                        offerDTO = _mapper.Map(vendor, offerDTO);
                    }
                }

                result.Add(offerDTO);
            }

            return result;
        }
    }
}
