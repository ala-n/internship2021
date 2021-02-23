using System;

namespace Xdl.Internship.Notifications.SDK.Configuration
{
    public class RabbitMQConfiguration
    {
        public string HostName { get; set; }

        public string QueueName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string VirtualHost { get; set; }

        public TimeSpan RequestedHeartbeat { get; set; }

        public string ExchangeName { get; set; }
    }
}
