using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.SDK.CityDTOs;

namespace Xdl.Internship.Offers.Handlers.City
{
    public class FindCityByIdHandler : IRequestHandler<FindCityByIdRequest, CityDTO>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public FindCityByIdHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<CityDTO> Handle(FindCityByIdRequest request, CancellationToken cancellationToken)
        {
            return _mapper.Map<CityDTO>(await _cityRepository.FindByIdAsync(request.Id));
        }
    }
}
