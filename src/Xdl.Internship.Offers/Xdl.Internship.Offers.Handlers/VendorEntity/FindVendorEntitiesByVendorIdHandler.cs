using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.SDK.VendorEntityDTOs;

namespace Xdl.Internship.Offers.Handlers.VendorEntity
{
    public class FindVendorEntitiesByVendorIdHandler : IRequestHandler<FindVendorEntitiesByVendorIdRequest, ICollection<VendorEntityDTO>>
    {
        private readonly IVendorEntityRepository _vendorEntityRepository;
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public FindVendorEntitiesByVendorIdHandler(IVendorEntityRepository vendorEntityRepository, ICityRepository cityRepository, IMapper mapper)
        {
            _vendorEntityRepository = vendorEntityRepository;
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<VendorEntityDTO>> Handle(FindVendorEntitiesByVendorIdRequest request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ICollection<VendorEntityDTO>>(await _vendorEntityRepository.FindByVendorIdAsync(request.VendorId, !request.IncludeInactive));
        }
    }
}
