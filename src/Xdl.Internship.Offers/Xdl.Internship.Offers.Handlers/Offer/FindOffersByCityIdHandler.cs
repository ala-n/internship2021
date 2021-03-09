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
    public class FindOffersByCityIdHandler : IRequestHandler<FindOffersByCityIdRequest, ICollection<OfferWithVendorInfoDTO>>
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IVendorEntityRepository _vendorEntityRepository;
        private readonly IVendorRepository _vendorRepository;
        private readonly IMapper _mapper;

        public FindOffersByCityIdHandler(IOfferRepository offerRepository, IVendorEntityRepository vendorEntityRepository, IVendorRepository vendorRepository,
            IMapper mapper)
        {
            _offerRepository = offerRepository;
            _vendorEntityRepository = vendorEntityRepository;
            _vendorRepository = vendorRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<OfferWithVendorInfoDTO>> Handle(FindOffersByCityIdRequest request, CancellationToken cancellationToken)
        {
            var entities = await _vendorEntityRepository.FindByCityAsync(request.CityId, request.OnlyActive);

            var vendorIds = entities.Select(e => e.VendorId).Distinct().ToList();
            var vendors = await _vendorRepository.FindByIdsAsync(vendorIds);

            var duplicateOffers = new List<Models.Offer> { };
            foreach (var en in entities)
            {
                var offerResults = await _offerRepository.FindByVendorEntityIdAsync(en.Id);
                if (offerResults.Count != 0)
                {
                    foreach (var e in offerResults)
                    {
                        duplicateOffers.Add(e);
                    }
                }
            }

            // Filters only unique offers
            var offers = duplicateOffers.GroupBy(o => o.Id);
            var vendorsByIdMap = vendors.ToDictionary(v => v.Id);
            var entitiesByIdMap = entities.ToDictionary(e => e.Id);

            var result = new List<OfferWithVendorInfoDTO> { };
            foreach (var offer in offers)
            {
                var offerDTO = _mapper.Map<OfferWithVendorInfoDTO>(offer.First());

                var offerEntities = new List<VendorEntityMainDTO>();
                Models.Vendor vendor = null;
                foreach (var id in offer.First().VendorEntitiesId)
                {
                    entitiesByIdMap.TryGetValue(id, out var entity);
                    if (entity == null)
                    {
                        continue;
                    }

                    offerEntities.Add(_mapper.Map<VendorEntityMainDTO>(entity));

                    // Get Vendor Info
                    if (vendor == null)
                    {
                        vendor = vendorsByIdMap.GetValueOrDefault(entity.VendorId);
                    }
                }

                offerDTO.VendorEntities = offerEntities;
                offerDTO = _mapper.Map(vendor, offerDTO);

                result.Add(offerDTO);
            }

            return result;
        }
    }
}
