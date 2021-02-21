using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Xdl.Internship.Notifications.ServiceHost.Configuration
{
    public class SMTPConfiguration
    {
        public string Address { get; set; }

        public int Port { get; set; }

        public string Password { get; set; }

        public string SenderEmail { get; set; }

        public string SenderName { get; set; }
    }
}
