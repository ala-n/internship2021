using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Offers.DataAccess.Repositories;
using Xdl.Internship.Offers.SDK.VendorEntityDTOs;

namespace Xdl.Internship.Offers.Handlers.VendorEntity
{
    public class InsertVendorEntityHandler : IRequestHandler<InsertVendorEntityRequest, VendorEntityDTO>
    {
        private readonly IVendorEntityRepository _vendorEntityRepository;
        private readonly IMapper _mapper;

        public InsertVendorEntityHandler(VendorEntityRepository vendorEntityRepository, IMapper mapper)
        {
            _vendorEntityRepository = vendorEntityRepository;
            _mapper = mapper;
        }

        public async Task<VendorEntityDTO> Handle(InsertVendorEntityRequest request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Models.VendorEntity>(request.VendorEntityDTO);
            entity.VendorId = request.VendorId;

            await _vendorEntityRepository.InsertOneAsync(entity);

            // TO-DO: make method that returns unique document
            return _mapper.Map<VendorEntityDTO>(await _vendorEntityRepository.FindOneByLocationAsync(entity.Location));
        }
    }
}
