using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.DataAccess.Repositories;
using Xdl.Internship.Offers.SDK.VendorDTOs;

namespace Xdl.Internship.Offers.Handlers.Offer
{
    public class GetVendorInfoByOfferIdHandler : IRequestHandler<GetVendorInfoByOfferIdRequest, VendorInfoForOfferDTO>
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IVendorEntityRepository _vendorEntityRepository;
        private readonly IVendorRepository _vendorRepository;
        private readonly IMapper _mapper;

        public GetVendorInfoByOfferIdHandler(OfferRepository offerRepository, VendorEntityRepository vendorEntityRepository, VendorRepository vendorRepository,
            IMapper mapper)
        {
            _offerRepository = offerRepository;
            _vendorEntityRepository = vendorEntityRepository;
            _vendorRepository = vendorRepository;
            _mapper = mapper;
        }

        public async Task<VendorInfoForOfferDTO> Handle(GetVendorInfoByOfferIdRequest request, CancellationToken cancellationToken)
        {
            var result = new List<VendorInfoForOfferDTO>();
            var offer = await _offerRepository.FindOfferById(request.OfferId);
            var entity = await _vendorEntityRepository.FindByIdAsync(offer.VendorEntitiesId.First());
            var vendor = await _vendorRepository.FindByIdAsync(entity.VendorId);
            return _mapper.Map<VendorInfoForOfferDTO>(vendor);
        }
    }
}