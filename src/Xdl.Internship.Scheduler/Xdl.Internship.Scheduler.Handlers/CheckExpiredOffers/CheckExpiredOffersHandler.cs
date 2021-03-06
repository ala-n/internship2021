using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Xdl.Internship.Core.RabbitMQ;

namespace Xdl.Internship.Scheduler.Handlers.CheckExpiredOffers
{
    public class CheckExpiredOffersHandler : IRequestHandler<CheckExpiredOffersRequest, bool>
    {
        private readonly IMessageSender<MessageDTO> _messageSender;

        public CheckExpiredOffersHandler(IMessageSender<MessageDTO> messageSender)
        {
            _messageSender = messageSender;
        }

        public async Task<bool> Handle(CheckExpiredOffersRequest request, CancellationToken cancellationToken)
        {
            MessageDTO messageDTO = new MessageDTO();

            await _messageSender.PublishAsync(messageDTO);

            return true;
        }
    }
}
