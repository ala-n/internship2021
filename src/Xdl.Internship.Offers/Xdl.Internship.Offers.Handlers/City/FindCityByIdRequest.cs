using System.Collections.Generic;
using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.SDK.CityDTOs;

namespace Xdl.Internship.Offers.Handlers.City
{
    public class FindCityByIdRequest : IRequest<ICollection<CityDTO>>
    {
        public ObjectId Id { get; }

        public FindCityByIdRequest(ObjectId id)
        {
            Id = id;
        }
    }
}
