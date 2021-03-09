using System;
using System.Collections.Generic;
using System.Text;

namespace Xdl.Internsip.Core.RabbitMQ.SDK
{
    public class EmailMessage : INotification
    {
        public string Id { get; set; }

        public string ClientName { get; set; }

        public string ClientPhone { get; set; }

        public string ClientComment { get; set; }

        public string EmailTo { get; set; }
    }
}
