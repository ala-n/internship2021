using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.DataAccess.Repositories;
using Xdl.Internship.Offers.Models;
using Xdl.Internship.Offers.SDK.CityDTOs;

namespace Xdl.Internship.Offers.Handlers.City
{
    public class FindCitiesHandler : IRequestHandler<FindCitiesRequest, ICollection<CityDTO>>
    {
        private readonly ICityRepository _cityRepository;
        private readonly IMapper _mapper;

        public FindCitiesHandler(CityRepository cityRepository, IMapper mapper)
        {
            _cityRepository = cityRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<CityDTO>> Handle(FindCitiesRequest request, CancellationToken cancellationToken)
        {
            return _mapper.Map<ICollection<CityDTO>>(await _cityRepository.FindActiveAsync());
        }
    }
}
