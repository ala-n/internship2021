using System;
using System.Threading.Tasks;

namespace Xdl.Internship.Scheduler.ServiceHost.Rabbit
{
    public interface IMessageSender<in TMsg>
        where TMsg : class, new()
    {
        Task PublishAsync(TMsg message);
    }
}
