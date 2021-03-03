using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.SDK.CityDTOs;

namespace Xdl.Internship.Offers.Handlers.City
{
    public class ReplaceCityHandler : IRequestHandler<ReplaceCityRequest, CityDTO>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public ReplaceCityHandler(ICityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<CityDTO> Handle(ReplaceCityRequest request, CancellationToken cancellationToken)
        {
            var oldCity = await _cityRepository.FindByIdAsync(request.Id);

            var city = _mapper.Map<Models.City>(request.CityDTO);
            city.Id = request.Id;
            city.CreatedAt = oldCity.CreatedAt;
            city.CreatedBy = oldCity.CreatedBy;
            city.IsActive = true;

            await _cityRepository.ReplaceOneAsync(city);

            return _mapper.Map<CityDTO>(await _cityRepository.FindByIdAsync(city.Id));
        }
    }
}
