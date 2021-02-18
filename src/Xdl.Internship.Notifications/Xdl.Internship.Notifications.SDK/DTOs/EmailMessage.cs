using System;
using System.Collections.Generic;
using System.Text;

namespace Xdl.Internship.Notifications.SDK.DTOs
{
    public class EmailMessage : INotification
    {
        public Guid Id { get; set; }

        public string To { get; set; }

        public string Subject { get; set; }

        public string Content { get; set; }
    }
}
