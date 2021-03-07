using System;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;

namespace Xdl.Internship.Core.RabbitMQ
{
    public class MessagePublisher : PublisherBase, IRabbitMqPublisher
    {
        private readonly string _queueName;

        public MessagePublisher(IOptions<RabbitMqConfiguration> rabbitMqOptions)
            : base(rabbitMqOptions)
        {
            _queueName = rabbitMqOptions.Value.QueueName;
        }

        public void Publish(byte[] body)
        {
            _modelAccessor.Value.BasicPublish(exchange: string.Empty, routingKey: _queueName, basicProperties: null, body: body);
        }

        protected override void DeclareQuee(IModel model)
        {
            model.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);
        }
    }
}
