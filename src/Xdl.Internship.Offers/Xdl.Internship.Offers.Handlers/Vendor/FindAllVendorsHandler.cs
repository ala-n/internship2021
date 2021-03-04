﻿using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.SDK.VendorDTOs;

namespace Xdl.Internship.Offers.Handlers.Vendor
{
    public class FindAllVendorsHandler : IRequestHandler<FindAllVendorsRequest, ICollection<VendorForAdminDTO>>
    {
        private readonly IVendorRepository _vendorRepository;
        private readonly IMapper _mapper;

        public FindAllVendorsHandler(IVendorRepository vendorRepository, IMapper mapper)
        {
            _vendorRepository = vendorRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<VendorForAdminDTO>> Handle(FindAllVendorsRequest request, CancellationToken cancellationToken)
        {
            var vendors = await _vendorRepository.FindAsync(request.IncludeInactive);
            var vendorDTO = new List<VendorForAdminDTO> { };

            foreach (var vendor in vendors)
            {
                vendorDTO.Add(_mapper.Map<VendorForAdminDTO>(vendor));
            }

            return vendorDTO;
        }
    }
}
