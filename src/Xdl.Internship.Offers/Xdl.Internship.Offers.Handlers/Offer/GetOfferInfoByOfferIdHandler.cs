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
    public class GetOfferInfoByOfferIdHandler : IRequestHandler<GetOfferInfoByOfferIdRequest, OfferWithAllInfoDTO>
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IVendorEntityRepository _vendorEntityRepository;
        private readonly IVendorRepository _vendorRepository;
        private readonly IMapper _mapper;

        public GetOfferInfoByOfferIdHandler(IOfferRepository offerRepository, IVendorEntityRepository vendorEntityRepository, IVendorRepository vendorRepository,
            IMapper mapper)
        {
            _offerRepository = offerRepository;
            _vendorEntityRepository = vendorEntityRepository;
            _vendorRepository = vendorRepository;
            _mapper = mapper;
        }

        public async Task<OfferWithAllInfoDTO> Handle(GetOfferInfoByOfferIdRequest request, CancellationToken cancellationToken)
        {
            var offer = await _offerRepository.FindByIdAsync(request.OfferId);

            var listOfEntities = new List<VendorEntityMainDTO>();
            foreach (var id in offer.VendorEntitiesId)
            {
                listOfEntities.Add(_mapper.Map<VendorEntityMainDTO>(await _vendorEntityRepository.FindByIdAsync(id)));
            }

            var entity = await _vendorEntityRepository.FindByIdAsync(offer.VendorEntitiesId.First());
            var vendor = await _vendorRepository.FindByIdAsync(entity.VendorId);

            ICollection<string> listOfTags = new List<string>();
            foreach (var id in offer.Tags)
            {
                listOfTags.Add(id.ToString());
            }

            return new OfferWithAllInfoDTO
            {
                Id = offer.Id.ToString(),
                Title = offer.Title,
                Description = offer.Description,
                CreatedBy = offer.CreatedBy,
                CreatedAt = offer.CreatedAt.ToString(),
                UpdatedBy = offer.UpdatedBy,
                UpdatedAt = offer.UpdatedAt.ToString(),
                NumberOfViews = offer.NumberOfViews,
                NumberOfUses = offer.NumberOfUses,
                Discount = offer.Discount,
                PromoCode = offer.PromoCode,
                DateStart = offer.DateStart.ToString(),
                DateEnd = offer.DateEnd.ToString(),
                Rate = offer.Rate,
                PhotoUrl = offer.PhotoUrl,
                VendorId = vendor.Id.ToString(),
                VendorName = vendor.Name,
                VendorEntities = listOfEntities,
                Tags = listOfTags,
            };
        }
    }
}
