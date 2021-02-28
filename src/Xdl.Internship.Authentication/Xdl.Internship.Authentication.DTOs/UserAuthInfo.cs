using System;
using System.Collections.Generic;
using System.Text;

namespace Xdl.Internship.Authentication.DTOs
{
    public class UserAuthInfo
    {
        public User UserDetails { get; set; }

        public string Token { get; set; }
    }
}
