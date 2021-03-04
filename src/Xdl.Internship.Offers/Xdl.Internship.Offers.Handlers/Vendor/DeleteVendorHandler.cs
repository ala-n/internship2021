using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.SDK.VendorDTOs;

namespace Xdl.Internship.Offers.Handlers.Vendor
{
    public class DeleteVendorHandler : IRequestHandler<DeleteVendorRequest>
    {
        private readonly IVendorRepository _vendorRepository;
        private readonly IMapper _mapper;

        public DeleteVendorHandler(IVendorRepository vendorEntityRepository, IMapper mapper)
        {
            _vendorRepository = vendorEntityRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteVendorRequest request, CancellationToken cancellationToken)
        {
            var vendor = await _vendorRepository.FindByIdAsync(request.Id);
            vendor.IsActive = false;

            await _vendorRepository.ReplaceOneAsync(vendor);

            return Unit.Value;
        }
    }
}
