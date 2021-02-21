using System;

namespace Xdl.Internship.Scheduler.ServiceHost.Rabbit
{
    public interface ISend
    {
        void Send(object obj);
    }
}
