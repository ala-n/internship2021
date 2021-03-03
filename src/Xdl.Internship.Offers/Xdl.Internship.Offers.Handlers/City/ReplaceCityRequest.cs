using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.SDK.CityDTOs;

namespace Xdl.Internship.Offers.Handlers.City
{
    public class ReplaceCityRequest : IRequest<CityDTO>
    {
        public ObjectId Id { get; }

        public UpdateCityDTO CityDTO { get; }

        public ReplaceCityRequest(ObjectId id, UpdateCityDTO cityDTO)
        {
            Id = id;
            CityDTO = cityDTO;
        }
    }
}
