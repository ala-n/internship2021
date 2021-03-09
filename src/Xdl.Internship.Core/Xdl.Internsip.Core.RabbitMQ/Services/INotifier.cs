using System;
using System.Collections.Generic;
using System.Text;

namespace Xdl.Internsip.Core.RabbitMQ.Services
{
    public interface INotifier<TMsg>
    {
        void SendAsync(TMsg notification);
    }
}
