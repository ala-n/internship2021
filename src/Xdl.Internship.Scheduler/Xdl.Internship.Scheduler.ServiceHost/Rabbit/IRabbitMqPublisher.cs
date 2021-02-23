using System;

namespace Xdl.Internship.Scheduler.ServiceHost.Rabbit
{
    public interface IRabbitMqPublisher
    {
        void Publish(byte[] body);
    }
}
