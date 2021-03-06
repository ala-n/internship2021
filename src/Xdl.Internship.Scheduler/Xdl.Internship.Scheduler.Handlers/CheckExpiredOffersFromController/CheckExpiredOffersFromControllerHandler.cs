using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Xdl.Internship.Core.RabbitMQ;

namespace Xdl.Internship.Scheduler.Handlers.CheckExpiredOffersFromController
{
    public class CheckExpiredOffersFromControllerHandler : IRequestHandler<CheckExpiredOffersFromControllerRequest, bool>
    {
        private readonly IMessageSender<MessageDTO> _messageSender;

        public CheckExpiredOffersFromControllerHandler(IMessageSender<MessageDTO> messageSender)
        {
            _messageSender = messageSender;
        }

        public async Task<bool> Handle(CheckExpiredOffersFromControllerRequest request, CancellationToken cancellationToken)
        {
            MessageDTO messageDTO = new MessageDTO();

            await _messageSender.PublishAsync(messageDTO);

            return true;
        }
    }
}
