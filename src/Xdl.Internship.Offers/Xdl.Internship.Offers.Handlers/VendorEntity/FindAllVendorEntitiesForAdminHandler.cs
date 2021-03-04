using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.SDK.VendorEntityDTOs;

namespace Xdl.Internship.Offers.Handlers.VendorEntity
{
    public class FindAllVendorEntitiesForAdminHandler : IRequestHandler<FindAllVendorEntitiesForAdminRequest, ICollection<VendorEntityForAdminDTO>>
    {
        private readonly IVendorEntityRepository _vendorEntityRepository;
        private readonly IMapper _mapper;

        public FindAllVendorEntitiesForAdminHandler(IVendorEntityRepository vendorEntityRepository, IMapper mapper)
        {
            _vendorEntityRepository = vendorEntityRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<VendorEntityForAdminDTO>> Handle(FindAllVendorEntitiesForAdminRequest request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ICollection<VendorEntityForAdminDTO>>(await _vendorEntityRepository.FindAsync(true));
        }
    }
}
