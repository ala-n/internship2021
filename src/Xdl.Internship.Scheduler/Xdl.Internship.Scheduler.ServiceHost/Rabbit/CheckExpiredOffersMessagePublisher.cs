using System;
using RabbitMQ.Client;

namespace Xdl.Internship.Scheduler.ServiceHost.Rabbit
{
    public class CheckExpiredOffersMessagePublisher : PublisherBase, IRabbitMqPublisher
    {
        public CheckExpiredOffersMessagePublisher() : base()
        {

        }
        protected override void DeclareQuee(IModel model)
        {
            model.QueueDeclare(queue: _queeName, durable: false, exclusive: false, autoDelete: false, arguments: null);
        }

        public void Publish(byte[] body)
        {
            
        }
    }
}
