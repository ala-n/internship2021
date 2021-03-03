using System.Collections.Generic;
using MediatR;
using Xdl.Internship.Offers.SDK.CityDTOs;

namespace Xdl.Internship.Offers.Handlers.City
{
    public class FindAllCitiesRequest : IRequest<ICollection<CityDTO>>
    {
        public bool IncludeInactive { get; }

        public FindAllCitiesRequest(bool includeInactive)
        {
            IncludeInactive = includeInactive;
        }
    }
}
