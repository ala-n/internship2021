using System;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace Xdl.Internship.Core.RabbitMQ
{
    public class MessageSender : IMessageSender<MessageDTO>
    {
        private readonly IRabbitMqPublisher _publisher;

        public MessageSender(IRabbitMqPublisher publisher)
        {
            _publisher = publisher;
        }

        public Task PublishAsync(MessageDTO message)
        {
            string jsonView = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(jsonView);

            _publisher.Publish(body);

            return Task.CompletedTask;
        }
    }
}
