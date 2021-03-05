using MongoDB.Bson;
using Xdl.Internship.Core.Models.MongoDB;

namespace Xdl.Internship.Authentication.DTOs
{
    public class User
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhotoUrl { get; set; }

        public bool IsActive { get; set; }

        public string City { get; set; }

        public string Role { get; set; }

        public string Phone { get; set; }
    }
}
