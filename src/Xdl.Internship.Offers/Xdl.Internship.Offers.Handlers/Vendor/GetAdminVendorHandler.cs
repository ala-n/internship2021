using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.SDK.VendorDTOs;

namespace Xdl.Internship.Offers.Handlers.Vendor
{
    public class GetAdminVendorHandler : IRequestHandler<GetAdminVendorRequest, ICollection<VendorAdminPanel>>
    {
        private readonly IVendorRepository _vendorRepository;
        private readonly IMapper _mapper;

        public GetAdminVendorHandler(IVendorRepository vendorRepository, IMapper mapper)
        {
            _vendorRepository = vendorRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<VendorAdminPanel>> Handle(GetAdminVendorRequest request, CancellationToken cancellationToken)
        {
            var data = await _vendorRepository.GetAllAdminVendors();
            return _mapper.Map<ICollection<VendorAdminPanel>>(data);
        }
    }
}