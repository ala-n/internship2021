using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.SDK.VendorDTOs;

namespace Xdl.Internship.Offers.Handlers.Vendor
{
    public class InsertVendorHandler : IRequestHandler<InsertVendorRequest, VendorMainDTO>
    {
        private readonly IVendorRepository _vendorRepository;
        private readonly IMapper _mapper;

        public InsertVendorHandler(IVendorRepository vendorEntityRepository, IMapper mapper)
        {
            _vendorRepository = vendorEntityRepository;
            _mapper = mapper;
        }

        public async Task<VendorMainDTO> Handle(InsertVendorRequest request, CancellationToken cancellationToken)
        {
            var vendor = _mapper.Map<Models.Vendor>(request.VendorDTO);

            // TO-DO: fill "createdBy" field
            vendor.Rate = 0;
            vendor.IsActive = true;

            await _vendorRepository.InsertOneAsync(vendor);

            return _mapper.Map<VendorMainDTO>(await _vendorRepository.FindByIdAsync(vendor.Id));
        }
    }
}
