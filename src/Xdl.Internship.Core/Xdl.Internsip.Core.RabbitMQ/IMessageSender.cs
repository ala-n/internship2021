using System;
using System.Threading.Tasks;

namespace Xdl.Internship.Core.RabbitMQ
{
    public interface IMessageSender<in TMsg>
        where TMsg : class, new()
    {
        Task PublishAsync(TMsg message);
    }
}
