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
    public class FindOfferByIdWithVendorInfoHandler : IRequestHandler<FindOfferByIdWithVendorInfoRequest, OfferWithVendorNameDTO>
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

        public async Task<OfferWithVendorNameDTO> Handle(FindOfferByIdWithVendorInfoRequest request, CancellationToken cancellationToken)
        {
            var offer = await _offerRepository.FindByIdAsync(request.Id);

            var result = _mapper.Map<OfferWithVendorNameDTO>(offer);
            if (offer.VendorEntitiesId.Count >= 1)
            {
                var entity = await _vendorEntityRepository.FindByIdAsync(offer.VendorEntitiesId.First());
                var vendor = await _vendorRepository.FindByIdAsync(entity.VendorId);
                result = _mapper.Map(vendor, result);
            }

            return result;
        }
    }
}
