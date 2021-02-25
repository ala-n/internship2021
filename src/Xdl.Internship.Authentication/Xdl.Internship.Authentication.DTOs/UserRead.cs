using System;
using System.Collections.Generic;
using System.Text;
using Xdl.Internship.Core.Models.MongoDB;

namespace Xdl.Internship.Authentication.DTOs
{
    public class UserRead : ModelBase
    {
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
