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
            var result = new List<OfferWithVendorInfoDTO>();
            foreach (var en in entities)
            {
                var offers = await _offerRepository.FindByVendorEntityIdAsync(en.Id);
                if (offers.Count != 0)
                {
                    foreach (var offer in offers)
                    {
                        var entity = await _vendorEntityRepository.FindByIdAsync(offer.VendorEntitiesId.First());
                        var vendor = await _vendorRepository.FindByIdAsync(entity.VendorId);

                        var listOfEntities = new List<VendorEntityMainDTO>();
                        foreach (var id in offer.VendorEntitiesId)
                        {
                            listOfEntities.Add(_mapper.Map<VendorEntityMainDTO>(await _vendorEntityRepository.FindByIdAsync(id)));
                        }

                        result.Add(new OfferWithVendorInfoDTO
                        {
                            Id = offer.Id.ToString(), Title = offer.Title, NumberOfViews = offer.NumberOfViews,
                            NumberOfUses = offer.NumberOfUses, Discount = offer.Discount, Rate = offer.Rate, UpdatedAt = offer.UpdatedAt.ToString(),
                            PhotoUrl = offer.PhotoUrl,
                            VendorId = vendor.Id.ToString(),
                            VendorName = vendor.Name,
                            VendorEntities = listOfEntities,
                        });
                    }
                }
            }

            return result;
        }
    }
}
