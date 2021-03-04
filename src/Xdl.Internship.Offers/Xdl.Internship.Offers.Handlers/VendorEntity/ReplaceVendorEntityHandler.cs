using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.SDK.VendorEntityDTOs;

namespace Xdl.Internship.Offers.Handlers.VendorEntity
{
    public class ReplaceVendorEntityHandler : IRequestHandler<ReplaceVendorEntityRequest, VendorEntityDTO>
    {
        private readonly IVendorEntityRepository _vendorEntityRepository;
        private readonly IMapper _mapper;

        public ReplaceVendorEntityHandler(IVendorEntityRepository vendorEntityRepository, IMapper mapper)
        {
            _vendorEntityRepository = vendorEntityRepository;
            _mapper = mapper;
        }

        public async Task<VendorEntityDTO> Handle(ReplaceVendorEntityRequest request, CancellationToken cancellationToken)
        {
            // Getting old value to copy audit fields
            var oldEntity = await _vendorEntityRepository.FindByIdAsync(request.Id);

            var entity = _mapper.Map<Models.VendorEntity>(request.VendorEntityDTO);
            entity.Id = request.Id;
            entity.CreatedBy = oldEntity.CreatedBy;
            entity.CreatedAt = oldEntity.CreatedAt;
            entity.IsActive = oldEntity.IsActive;
            entity.Rate = oldEntity.Rate;
            entity.VendorId = oldEntity.VendorId;

            await _vendorEntityRepository.ReplaceOneAsync(entity);

            return _mapper.Map<VendorEntityDTO>(await _vendorEntityRepository.FindByIdAsync(request.Id));
        }
    }
}
