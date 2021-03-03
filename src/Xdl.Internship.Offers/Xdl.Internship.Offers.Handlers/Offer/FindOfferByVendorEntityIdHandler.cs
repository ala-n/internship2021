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
    public class FindOfferByVendorEntityIdHandler : IRequestHandler<FindOfferByVendorEntityIdRequest, ICollection<OfferMainDTO>>
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IMapper _mapper;

        public FindOfferByVendorEntityIdHandler(IOfferRepository offerRepository, IMapper mapper)
        {
            _offerRepository = offerRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<OfferMainDTO>> Handle(FindOfferByVendorEntityIdRequest request, CancellationToken cancellationToken)
        {
            var entities = await _offerRepository.FindByVendorEntityIdAsync(request.VendorEntityId);
            var result = new List<OfferMainDTO> { };
            foreach (var en in entities)
            {
                result.Add(_mapper.Map<OfferMainDTO>(en));
            }

            return result;
        }
    }
}
