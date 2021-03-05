using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.DataAccess.Repositories;
using Xdl.Internship.Offers.SDK.VendorEntityDTOs;

namespace Xdl.Internship.Offers.Handlers.VendorEntity
{
    public class GetVendorEntitiesByOfferIdHandler : IRequestHandler<GetVendorEntitiesByOfferIdRequest, ICollection<VendorEntityMainDTO>>
    {
        private readonly IVendorEntityRepository _vendorEntityRepository;
        private readonly IOfferRepository _offerRepository;
        private readonly IMapper _mapper;

        public GetVendorEntitiesByOfferIdHandler(VendorEntityRepository vendorEntityRepository, OfferRepository offerRepository, IMapper mapper)
        {
            _vendorEntityRepository = vendorEntityRepository;
            _offerRepository = offerRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<VendorEntityMainDTO>> Handle(GetVendorEntitiesByOfferIdRequest request, CancellationToken cancellationToken)
        {
            var result = new List<VendorEntityMainDTO> { };
            var offer = await _offerRepository.FindByIdAsync(request.OfferId);
            if (offer != null)
            {
                foreach (var entity in offer.VendorEntitiesId)
                {
                    result.Add(_mapper.Map<VendorEntityMainDTO>(await _vendorEntityRepository.FindByIdAsync(entity)));
                }
            }

            return result;
        }
    }
}