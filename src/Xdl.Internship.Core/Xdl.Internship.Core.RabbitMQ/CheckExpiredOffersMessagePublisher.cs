using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace Xdl.Internship.Core.RabbitMQ
{
    public class CheckExpiredOffersMessagePublisher : PublisherBase, IRabbitMqPublisher
    {
        protected string GetThisClassName()
        {
            return GetType().Name;
        }

        public CheckExpiredOffersMessagePublisher(IOptions<RabbitMQConfiguration> rabbitMqOptions)
            : base(rabbitMqOptions)
        {
        }

        protected override void DeclareQueue(IModel model)
        {
            model.QueueDeclare(queue: GetThisClassName(), durable: false, exclusive: false, autoDelete: false, arguments: null);
        }
    }
}
