using MongoDB.Bson;
using Xdl.Internship.Core.Models.MongoDB;

namespace Xdl.Internship.Authentication.DTOs
{
    public class UserRead
    {
        public ObjectId Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Login { get; set; }

        public string PhotoUrl { get; set; }

        public bool IsActive { get; set; }

        public string City { get; set; }

        public int Role { get; set; }

        public string Token { get; set; }
    }
}
