using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Offers.DataAccess.Interfaces;

namespace Xdl.Internship.Offers.Handlers.Vendor
{
    public class ReplaceVendorHandler : INotificationHandler<ReplaceVendorRequest>
    {
        private readonly IVendorRepository _vendorRepository;
        private readonly IMapper _mapper;

        public ReplaceVendorHandler(IVendorRepository vendorEntityRepository, IMapper mapper)
        {
            _vendorRepository = vendorEntityRepository;
            _mapper = mapper;
        }

        public async Task Handle(ReplaceVendorRequest request, CancellationToken cancellationToken)
        {
            // Getting old value to copy audit fields
            var oldVendor = await _vendorRepository.FindByIdAsync(request.Id);

            var vendor = _mapper.Map(request.VendorDTO, oldVendor);

            await _vendorRepository.ReplaceOneAsync(vendor);
        }
    }
}
