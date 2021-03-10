using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.SDK.VendorEntityDTOs;

namespace Xdl.Internship.Offers.Handlers.VendorEntity
{
    public class ReplaceVendorEntityHandler : INotificationHandler<ReplaceVendorEntityRequest>
    {
        private readonly IVendorEntityRepository _vendorEntityRepository;
        private readonly IMapper _mapper;

        public ReplaceVendorEntityHandler(IVendorEntityRepository vendorEntityRepository, IMapper mapper)
        {
            _vendorEntityRepository = vendorEntityRepository;
            _mapper = mapper;
        }

        public async Task Handle(ReplaceVendorEntityRequest request, CancellationToken cancellationToken)
        {
            // Getting old value to copy audit fields
            var oldEntity = await _vendorEntityRepository.FindByIdAsync(request.Id);

            var entity = _mapper.Map(request.VendorEntityDTO, oldEntity);
            entity = _mapper.Map(request.Identity, entity);

            await _vendorEntityRepository.ReplaceOneAsync(entity);

            // return _mapper.Map<VendorEntityDTO>(entity);
        }
    }
}
