using System;
using Xdl.Internship.Core.Models.MongoDB;

namespace Xdl.Internship.Authentication.Models
{
    public class User : ModelBase, IUpdationAwareModel
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string PhotoUrl { get; set; }

        public bool IsActive { get; set; }

        public string City { get; set; }

        public Role Role { get; set; }

        public string Phone { get; set; }

        public string Token { get; set; }

        public string UpdatedBy { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}
