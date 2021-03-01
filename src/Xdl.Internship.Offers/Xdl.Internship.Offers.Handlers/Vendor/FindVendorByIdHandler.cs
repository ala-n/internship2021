using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.DataAccess.Repositories;
using Xdl.Internship.Offers.Models;
using Xdl.Internship.Offers.SDK.VendorDTOs;
using Xdl.Internship.Offers.SDK.VendorEntityDTOs;

namespace Xdl.Internship.Offers.Handlers.Vendor
{
    public class FindVendorByIdHandler : IRequestHandler<FindVendorByIdRequest, VendorWithEntitiesDTO>
    {
        private readonly IVendorRepository _vendorRepository;
        private readonly IVendorEntityRepository _vendorEntityRepository;
        private readonly IMapper _mapper;

        public FindVendorByIdHandler(VendorRepository vendorRepository, VendorEntityRepository vendorEntityRepository, IMapper mapper)
        {
            _vendorRepository = vendorRepository;
            _vendorEntityRepository = vendorEntityRepository;
            _mapper = mapper;
        }

        public async Task<VendorWithEntitiesDTO> Handle(FindVendorByIdRequest request, CancellationToken cancellationToken)
        {
            var vendor = await _vendorRepository.FindByIdAsync(request.Id);

            var result = _mapper.Map<VendorWithEntitiesDTO>(vendor);

            if (request.IncludeEntites)
            {
                var entities = await _vendorEntityRepository.FindByVendorId(request.Id);
                result.VendorEntities = _mapper.Map<ICollection<VendorEntityDTO>>(entities);
            }

            return result;
        }
    }
}
