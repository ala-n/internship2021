using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.SDK.VendorDTOs;

namespace Xdl.Internship.Offers.Handlers.Vendor
{
    public class FindVendorByIdForAdminHandler : IRequestHandler<FindVendorByIdForAdminRequest, VendorMainDTO>
    {
        private readonly IVendorRepository _vendorRepository;
        private readonly IMapper _mapper;

        public FindVendorByIdForAdminHandler(IVendorRepository vendorRepository, IMapper mapper)
        {
            _vendorRepository = vendorRepository;
            _mapper = mapper;
        }

        public async Task<VendorMainDTO> Handle(FindVendorByIdForAdminRequest request, CancellationToken cancellationToken)
        {
            return _mapper.Map<VendorMainDTO>(await _vendorRepository.FindByIdAsync(request.Id));
        }
    }
}
