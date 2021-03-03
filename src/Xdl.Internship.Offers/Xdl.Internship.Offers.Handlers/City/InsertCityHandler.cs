using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.SDK.CityDTOs;

namespace Xdl.Internship.Offers.Handlers.City
{
    public class InsertCityHandler : IRequestHandler<InsertCityRequest, CityDTO>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public InsertCityHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<CityDTO> Handle(InsertCityRequest request, CancellationToken cancellationToken)
        {
            var city = _mapper.Map<Models.City>(request.CityDTO);

            await _cityRepository.InsertOneAsync(city);

            return _mapper.Map<CityDTO>(await _cityRepository.FindByIdAsync(city.Id));
        }
    }
}
