using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.DataAccess.Repositories;
using Xdl.Internship.Offers.SDK.OfferDTOs;

namespace Xdl.Internship.Offers.Handlers.Offer
{
    public class FindOffersByVendorIdHandler : IRequestHandler<FindOffersByVendorIdRequest, ICollection<OfferMainDTO>>
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IVendorEntityRepository _vendorEntityRepository;
        private readonly IMapper _mapper;

        public FindOffersByVendorIdHandler(OfferRepository offerRepository, VendorEntityRepository vendorEntityRepository, IMapper mapper)
        {
            _offerRepository = offerRepository;
            _vendorEntityRepository = vendorEntityRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<OfferMainDTO>> Handle(FindOffersByVendorIdRequest request, CancellationToken cancellationToken)
        {
            var entities = await _vendorEntityRepository.FindByVendorId(request.VendorId);
            var result = new List<OfferMainDTO> { };
            foreach (var en in entities)
            {
                result.Add(_mapper.Map<OfferMainDTO>(_offerRepository.FindOfferByVendorEntityId(en.Id)));
            }

            return result;
        }
    }
}
