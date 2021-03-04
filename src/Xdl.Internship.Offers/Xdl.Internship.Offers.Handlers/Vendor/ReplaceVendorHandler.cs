using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.SDK.VendorDTOs;

namespace Xdl.Internship.Offers.Handlers.Vendor
{
    public class ReplaceVendorHandler : IRequestHandler<ReplaceVendorRequest, VendorDTO>
    {
        private readonly IVendorRepository _vendorRepository;
        private readonly IMapper _mapper;

        public ReplaceVendorHandler(IVendorRepository vendorEntityRepository, IMapper mapper)
        {
            _vendorRepository = vendorEntityRepository;
            _mapper = mapper;
        }

        public async Task<VendorDTO> Handle(ReplaceVendorRequest request, CancellationToken cancellationToken)
        {
            // Getting old value to copy audit fields
            var oldVendor = await _vendorRepository.FindByIdAsync(request.Id);

            var vendor = _mapper.Map<Models.Vendor>(request.VendorDTO);
            vendor.Id = request.Id;
            vendor.CreatedAt = oldVendor.CreatedAt;
            vendor.CreatedBy = oldVendor.CreatedBy;
            vendor.IsActive = oldVendor.IsActive;
            vendor.Rate = oldVendor.Rate;

            await _vendorRepository.ReplaceOneAsync(vendor);

            return _mapper.Map<VendorDTO>(await _vendorRepository.FindByIdAsync(vendor.Id));
        }
    }
}
