using System.Collections.Generic;
using MediatR;
using Xdl.Internship.Offers.SDK.CityDTOs;

namespace Xdl.Internship.Offers.Handlers.City
{
    public class InsertCityRequest : IRequest<CityDTO>
    {
        public CreateCityDTO CityDTO { get; }

        public InsertCityRequest(CreateCityDTO cityDTO)
        {
            CityDTO = cityDTO;
        }
    }
}
