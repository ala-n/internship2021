﻿using System;
using System.Collections.Generic;
using System.Linq;
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
        private readonly IVendorEntityRepository _vendorEntityRepository;
        private readonly IMapper _mapper;

        public FindOffersByCityIdHandler(OfferRepository offerRepository, VendorEntityRepository vendorEntityRepository, IMapper mapper)
        {
            _offerRepository = offerRepository;
            _vendorEntityRepository = vendorEntityRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<OfferForListDTO>> Handle(FindOffersByCityIdRequest request, CancellationToken cancellationToken)
        {
            var entities = await _vendorEntityRepository.FindByCityAsync(request.CityId, request.OnlyActive);
            var result = new List<OfferForListDTO> { };
            foreach (var en in entities)
            {
                result.Add(_mapper.Map<OfferForListDTO>(_offerRepository.FindOfferByVendorEntityId(en.Id)));
            }

            return result;
        }
    }
}
