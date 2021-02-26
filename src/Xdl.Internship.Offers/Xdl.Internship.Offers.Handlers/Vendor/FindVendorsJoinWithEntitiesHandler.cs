using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.DataAccess.Repositories;
using Xdl.Internship.Offers.DTOs.VendorDTOs;

namespace Xdl.Internship.Offers.Handlers.Vendor
{
    public class FindVendorsJoinWithEntitiesHandler : IRequestHandler<FindVendorsJoinWithEntitiesRequest, ICollection<VendorWithEntitiesDTO>>
    {
        private readonly IVendorRepository _vendorRepository;
        private readonly IVendorEntityRepository _vendorEntityRepository;
        private readonly IMapper _mapper;

        public FindVendorsJoinWithEntitiesHandler(VendorRepository vendorRepository, VendorEntityRepository vendorEntityRepository, IMapper mapper)
        {
            _vendorRepository = vendorRepository;
            _vendorEntityRepository = vendorEntityRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<VendorWithEntitiesDTO>> Handle(FindVendorsJoinWithEntitiesRequest request, CancellationToken cancellationToken)
        {
            var entities = await _vendorEntityRepository.FindActiveAsync();

            var vendorIds = new HashSet<ObjectId>() { };
            foreach (var entity in entities)
            {
                vendorIds.Add(entity.Id);
            }


        }
    }
}
