using System;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Xdl.Internship.Scheduler.ServiceHost.Rabbit
{
    public class CheckExpiredOffersMessageSender : IMessageSender<CheckExpiredOffersMessageDTO>
    {
        private readonly IRabbitMqPublisher _publisher;

        public CheckExpiredOffersMessageSender(IRabbitMqPublisher publisher, ILogger<CheckExpiredOffersMessageSender> logger)
        {
            _publisher = publisher;
        }

        public Task PublishAsync(CheckExpiredOffersMessageDTO message)
        {
            string jsonView = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(jsonView);

            _publisher.Publish(body);

            return Task.CompletedTask;
        }
    }
}
