using MongoDB.Bson;

namespace Xdl.Internship.Offers.Models
{
    public class Adress
    {
        public string Country { get; set; }

        public ObjectId CityId { get; set; }

        public string Street { get; set; }

        public string House { get; set; }

        public string Room { get; set; }
    }
}
