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
    public class FindVendorEntitiesByVendorIdHandler : IRequestHandler<FindVendorEntitiesByVendorIdRequest, ICollection<VendorEntityForAdminDTO>>
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

        public async Task<ICollection<VendorEntityForAdminDTO>> Handle(FindVendorEntitiesByVendorIdRequest request, CancellationToken cancellationToken)
        {
            // What with Inactive CITIES
            var entities = await _vendorEntityRepository.FindAsync(true);
            var cities = await _cityRepository.FindAsync(true);

            var citiesByIdMap = cities.ToDictionary(c => c.Id);

            ICollection<VendorEntityForAdminDTO> result = new List<VendorEntityForAdminDTO>();
            foreach (var entity in entities)
            {
                var entityDTO = _mapper.Map<VendorEntityForAdminDTO>(entity);

                if (entity.Adress == null || entity.Adress.CityId == null)
                {
                    // TO-DO: log
                }
                else
                {
                    if (citiesByIdMap.TryGetValue(entity.Adress.CityId, out var city))
                    {
                        entityDTO.City = city.Name;
                    }
                }

                result.Add(entityDTO);
            }

            return result;
        }
    }
}
