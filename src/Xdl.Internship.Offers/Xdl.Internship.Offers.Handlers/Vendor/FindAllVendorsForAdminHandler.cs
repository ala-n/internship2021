using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.SDK.VendorDTOs;

namespace Xdl.Internship.Offers.Handlers.Vendor
{
    public class FindAllVendorsForAdminHandler : IRequestHandler<FindAllVendorsForAdminRequest, ICollection<VendorForAdminDTO>>
    {
        private readonly IVendorRepository _vendorRepository;
        private readonly IMapper _mapper;

        public FindAllVendorsForAdminHandler(IVendorRepository vendorRepository, IMapper mapper)
        {
            _vendorRepository = vendorRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<VendorForAdminDTO>> Handle(FindAllVendorsForAdminRequest request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ICollection<VendorForAdminDTO>>(await _vendorRepository.FindAsync(true));
        }
    }
}
