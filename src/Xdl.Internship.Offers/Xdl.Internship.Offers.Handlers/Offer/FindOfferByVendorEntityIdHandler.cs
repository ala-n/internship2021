using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.DataAccess.Repositories;
using Xdl.Internship.Offers.SDK.OffersDTOs;

namespace Xdl.Internship.Offers.Handlers.Offer
{
    public class FindOfferByVendorEntityIdHandler : IRequestHandler<FindOfferByVendorEntityIdRequest, ICollection<OfferMainDTO>>
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IMapper _mapper;

        public FindOfferByVendorEntityIdHandler(OfferRepository offerRepository, IMapper mapper)
        {
            _offerRepository = offerRepository;
            _mapper = mapper;
        }

        public Task<ICollection<OfferMainDTO>> Handle(FindOfferByVendorEntityIdRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
