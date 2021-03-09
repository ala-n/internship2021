using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.SDK.VendorEntityDTOs;

namespace Xdl.Internship.Offers.Handlers.VendorEntity
{
    public class FindVendorEntityByIdHandler : IRequestHandler<FindVendorEntityByIdRequest, VendorEntityWithVendorNameDTO>
    {
        private readonly IVendorEntityRepository _vendorEntityRepository;
        private readonly IVendorRepository _vendorRepository;
        private readonly IMapper _mapper;

        public FindVendorEntityByIdHandler(IVendorEntityRepository vendorEntityRepository, IVendorRepository vendorRepository, IMapper mapper)
        {
            _vendorEntityRepository = vendorEntityRepository;
            _vendorRepository = vendorRepository;
            _mapper = mapper;
        }

        public async Task<VendorEntityWithVendorNameDTO> Handle(FindVendorEntityByIdRequest request, CancellationToken cancellationToken)
        {
            var entity = await _vendorEntityRepository.FindByIdAsync(request.Id);

            var result = _mapper.Map<VendorEntityWithVendorNameDTO>(entity);
            if (entity != null && entity.VendorId != null)
            {
                var vendor = await _vendorRepository.FindByIdAsync(entity.VendorId);
                result = _mapper.Map(vendor, result);
            }

            return result;
        }
    }
}
