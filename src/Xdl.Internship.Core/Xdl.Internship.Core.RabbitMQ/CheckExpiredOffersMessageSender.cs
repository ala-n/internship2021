using Microsoft.Extensions.Logging;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Xdl.Internship.Core.DTOs;

namespace Xdl.Internship.Core.RabbitMQ
{
    public class CheckExpiredOffersMessageSender : IMessageSender<CheckExpiredOffersMessage>
    {
        private readonly IRabbitMqPublisher _publisher;

        public CheckExpiredOffersMessageSender(IRabbitMqPublisher publisher, ILogger<CheckExpiredOffersMessageSender> logger)
        {
            _publisher = publisher;
        }

        public Task PublishAsync(CheckExpiredOffersMessage message)
        {
            string jsonView = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(jsonView);

            _publisher.Publish(body);

            return Task.CompletedTask;
        }
    }
}
