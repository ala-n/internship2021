using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Offers.DataAccess.Repositories;
using Xdl.Internship.Offers.SDK.VendorEntityDTOs;

namespace Xdl.Internship.Offers.Handlers.VendorEntity
{
    public class FindVendorEntityByIdHandler : IRequestHandler<FindVendorEntityByIdRequest, VendorEntityDTO>
    {
        private readonly IVendorEntityRepository _vendorEntityRepository;
        private readonly IMapper _mapper;

        public FindVendorEntityByIdHandler(VendorEntityRepository vendorEntityRepository, IMapper mapper)
        {
            _vendorEntityRepository = vendorEntityRepository;
            _mapper = mapper;
        }

        public async Task<VendorEntityDTO> Handle(FindVendorEntityByIdRequest request, CancellationToken cancellationToken)
        {
            return _mapper.Map<VendorEntityDTO>(await _vendorEntityRepository.FindByIdAsync(request.Id));
        }
    }
}
