using System;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace Xdl.Internship.Scheduler.ServiceHost.Rabbit
{
    public class CheckExpiredOffersMessagePublisher : PublisherBase, IRabbitMqPublisher
    {
        protected string GetThisClassName()
        {
            return GetType().Name;
        }

        public CheckExpiredOffersMessagePublisher(IOptions<RabbitMqConfiguration> rabbitMqOptions)
            : base(rabbitMqOptions)
        {
        }

        protected override void DeclareQuee(IModel model)
        {
            model.QueueDeclare(queue: GetThisClassName(), durable: false, exclusive: false, autoDelete: false, arguments: null);
        }
    }
}
