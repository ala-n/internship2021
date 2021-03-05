using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.Handlers.Vendor;

namespace Xdl.Internship.Offers.Handlers.VendorEntity
{
    public class MakeVendorEntitiesInactiveByVendorIdHandler : INotificationHandler<ReplaceVendorRequest>
    {
        private readonly IVendorEntityRepository _vendorEntityRepository;
        private readonly IMapper _mapper;

        public MakeVendorEntitiesInactiveByVendorIdHandler(IVendorEntityRepository vendorEntityRepository, IMapper mapper)
        {
            _vendorEntityRepository = vendorEntityRepository;
            _mapper = mapper;
        }

        public async Task Handle(ReplaceVendorRequest request, CancellationToken cancellationToken)
        {
            // execute only if IsActive set to FALSE
            if (request.VendorDTO.IsActive)
            {
                return;
            }

            var entities = await _vendorEntityRepository.FindByVendorIdAsync(request.Id, true);

            foreach (var entity in entities)
            {
                entity.IsActive = false;
                await _vendorEntityRepository.ReplaceOneAsync(entity);
            }
        }
    }
}
