using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.SDK.OfferDTOs;

namespace Xdl.Internship.Offers.Handlers.Offer
{
    public class FindOffersByVendorIdHandler : IRequestHandler<FindOffersByVendorIdRequest, ICollection<OfferMainDTO>>
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IVendorEntityRepository _vendorEntityRepository;
        private readonly IMapper _mapper;

        public FindOffersByVendorIdHandler(IOfferRepository offerRepository, IVendorEntityRepository vendorEntityRepository, IMapper mapper)
        {
            _offerRepository = offerRepository;
            _vendorEntityRepository = vendorEntityRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<OfferMainDTO>> Handle(FindOffersByVendorIdRequest request, CancellationToken cancellationToken)
        {
            var entities = await _vendorEntityRepository.FindByVendorIdAsync(request.VendorId, true);
            var result = new List<OfferMainDTO> { };
            foreach (var en in entities)
            {
                var entity = await _offerRepository.FindByVendorEntityIdAsync(en.Id);
                if (entity.Count != 0)
                {
                    foreach (var e in entity)
                    {
                        result.Add(_mapper.Map<OfferMainDTO>(e));
                    }
                }
            }

            return result;
        }
    }
}
