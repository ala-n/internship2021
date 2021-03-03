using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.DataAccess.Repositories;
using Xdl.Internship.Offers.SDK.VendorDTOs;
using Xdl.Internship.Offers.SDK.VendorEntityDTOs;

namespace Xdl.Internship.Offers.Handlers.Vendor
{
    public class FindVendorsWithEntitiesHandler : IRequestHandler<FindVendorsWithEntitiesRequest, ICollection<VendorWithEntitiesDTO>>
    {
        private readonly IVendorRepository _vendorRepository;
        private readonly IVendorEntityRepository _vendorEntityRepository;
        private readonly IMapper _mapper;

        public FindVendorsWithEntitiesHandler(IVendorRepository vendorRepository, IVendorEntityRepository vendorEntityRepository, IMapper mapper)
        {
            _vendorRepository = vendorRepository;
            _vendorEntityRepository = vendorEntityRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<VendorWithEntitiesDTO>> Handle(FindVendorsWithEntitiesRequest request, CancellationToken cancellationToken)
        {
            // Getting all Entitties
            var entities = await _vendorEntityRepository.FindByCityAsync(request.CityId, request.OnlyActive);

            // Filtering unique values
            ICollection<ObjectId> vendorIds = entities.Select(e => e.VendorId).Distinct().ToList();

            var vendors = await _vendorRepository.FindByIdsAsync(vendorIds);

            var entitiesByVendor = entities.GroupBy(e => e.VendorId);
            var vendorsByIdMap = vendors.ToDictionary(v => v.Id);

            ICollection<VendorWithEntitiesDTO> result = new List<VendorWithEntitiesDTO>();
            foreach (var vendorEntities in entitiesByVendor)
            {
                var vendorId = vendorEntities.Key;
                if (vendorsByIdMap.TryGetValue(vendorId, out var vendor))
                {
                    var vendorWithEntitiesDTO = _mapper.Map<VendorWithEntitiesDTO>(vendor);
                    vendorWithEntitiesDTO.VendorEntities = _mapper.Map<ICollection<VendorEntityDTO>>(vendorEntities);
                    result.Add(vendorWithEntitiesDTO);
                }
            }

            return result;
        }
    }
}
