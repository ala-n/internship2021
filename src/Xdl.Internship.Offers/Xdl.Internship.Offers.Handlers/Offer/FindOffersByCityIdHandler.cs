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
    public class FindOffersByCityIdHandler : IRequestHandler<FindOffersByCityIdRequest, ICollection<OfferForListDTO>>
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IMapper _mapper;

        public FindOffersByCityIdHandler(OfferRepository offerRepository, IMapper mapper)
        {
            _offerRepository = offerRepository;
            _mapper = mapper;
        }

        public Task<ICollection<OfferForListDTO>> Handle(FindOffersByCityIdRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
