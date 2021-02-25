using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace Xdl.Internship.Core.RabbitMQ.SDK
{
    public class CheckExpiredOffersMessagePublisher : PublisherBase, IRabbitMqPublisher
    {
        private readonly string _queueName;

        public CheckExpiredOffersMessagePublisher(IOptions<RabbitMQConfiguration> rabbitMqOptions)
            : base(rabbitMqOptions)
        {
            _queueName = rabbitMqOptions.Value.QueueName; 
        }

        protected override void DeclareQueue(IModel model)
        {
            model.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
        }
    }
}
