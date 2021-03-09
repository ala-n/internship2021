using System;
using System.Collections.Generic;
using System.Text;

namespace Xdl.Internship.Offers.SDK.Identity
{
    public class UpdateIdentity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public UpdateIdentity()
        {
        }

        public UpdateIdentity(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public string GetValue()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
