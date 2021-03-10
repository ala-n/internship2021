using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.SDK.VendorEntityDTOs;

namespace Xdl.Internship.Offers.Handlers.VendorEntity
{
    public class InsertVendorEntityHandler : IRequestHandler<InsertVendorEntityRequest, VendorEntityDTO>
    {
        private readonly IVendorEntityRepository _vendorEntityRepository;
        private readonly IVendorRepository _vendorRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public InsertVendorEntityHandler(IVendorEntityRepository vendorEntityRepository, IVendorRepository vendorRepository, ICityRepository cityRepository, IMapper mapper)
        {
            _vendorEntityRepository = vendorEntityRepository;
            _vendorRepository = vendorRepository;
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<VendorEntityDTO> Handle(InsertVendorEntityRequest request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Models.VendorEntity>(request.VendorEntityDTO);
            entity.VendorId = request.VendorId;
            entity = _mapper.Map(request.Identity, entity);

            // TO-DO: implement validation check, return error msg
            if (await _vendorRepository.FindByIdAsync(request.VendorId) == null)
            {
            }
            else if (await _cityRepository.FindByIdAsync(entity.Address.CityId) == null)
            {
            }

            await _vendorEntityRepository.InsertOneAsync(entity);

            return _mapper.Map<VendorEntityDTO>(await _vendorEntityRepository.FindOneByLocationAsync(entity.Location));
        }
    }
}
