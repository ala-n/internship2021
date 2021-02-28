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
using Xdl.Internship.Offers.Models;
using Xdl.Internship.Offers.SDK.VendorDTOs;
using Xdl.Internship.Offers.SDK.VendorEntityDTOs;

namespace Xdl.Internship.Offers.Handlers.Vendor
{
    public class FindVendorsWithEntitiesHandler : IRequestHandler<FindVendorsWithEntitiesRequest, ICollection<VendorWithEntitiesDTO>>
    {
        private readonly IVendorRepository _vendorRepository;
        private readonly IVendorEntityRepository _vendorEntityRepository;
        private readonly IMapper _mapper;

        public FindVendorsWithEntitiesHandler(VendorRepository vendorRepository, VendorEntityRepository vendorEntityRepository, IMapper mapper)
        {
            _vendorRepository = vendorRepository;
            _vendorEntityRepository = vendorEntityRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<VendorWithEntitiesDTO>> Handle(FindVendorsWithEntitiesRequest request, CancellationToken cancellationToken)
        {
            // Getting all Entitties
            if (ObjectId.TryParse(request.CityId, var ))
            {

            }
            var entities = await _vendorEntityRepository.FindByCityAsync(ObjectId.Parse(request.CityId), request.OnlyActive);
 
            // Filtering unique values
            ICollection<ObjectId> vendorIds = (ICollection<ObjectId>)entities.Select(e => e.VendorId).Distinct();

            var vendors = _vendorRepository.FindByIdsAsync(vendorIds);

            var res = _mapper.Map<IList<VendorWithEntitiesDTO>>(vendors);
            foreach (var entity in entities)
            {
                for (var i = 0; i < res.Count; i++)
                {
                    if (entity.VendorId == res[i].Id)
                    {
                        res[i].VendorEntities.Add(entity);
                    }
                }
            }

            return res;
        }
    }
}
