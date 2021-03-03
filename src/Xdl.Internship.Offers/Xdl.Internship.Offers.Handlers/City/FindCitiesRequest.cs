using System.Collections.Generic;
using MediatR;
using Xdl.Internship.Offers.SDK.CityDTOs;

namespace Xdl.Internship.Offers.Handlers.City
{
    public class FindCitiesRequest : IRequest<ICollection<CityDTO>>
    {
    }
}
