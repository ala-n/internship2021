using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Offers.DataAccess.Interfaces;

namespace Xdl.Internship.Offers.Handlers.VendorEntity
{
    public class DeleteVendorEntityHandler : IRequestHandler<DeleteVendorEntityRequest>
    {
        private readonly IVendorEntityRepository _vendorEntityRepository;
        private readonly IMapper _mapper;

        public DeleteVendorEntityHandler(IVendorEntityRepository vendorEntityRepository, IMapper mapper)
        {
            _vendorEntityRepository = vendorEntityRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteVendorEntityRequest request, CancellationToken cancellationToken)
        {
            var entity = await _vendorEntityRepository.FindByIdAsync(request.Id);
            entity.IsActive = false;

            await _vendorEntityRepository.ReplaceOneAsync(entity);

            return Unit.Value;
        }
    }
}
