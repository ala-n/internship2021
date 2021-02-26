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
using Xdl.Internship.Offers.DTOs.VendorEntityDTOs;
using Xdl.Internship.Offers.Models;

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
            // Getting all Entitties
            var entities = _mapper.Map<ICollection<VendorEntityDTO>>(await _vendorEntityRepository.FindActiveAsync());

            // Filtering unique values
            var vendorIds = new HashSet<ObjectId>() { };
            var taskList = new List<Task<Models.Vendor>>() { };
            foreach (var entity in entities)
            {
                if (vendorIds.Add(entity.VendorId))
                {
                    taskList.Add(_vendorRepository.FindByIdAsync(entity.VendorId));
                }
            }

            var vendors = _mapper.Map<List<VendorDTO>>(await Task.WhenAll(taskList));

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
