using System;
using System.Collections.Generic;
using System.Text;
using Xdl.Internship.Notifications.SDK.DTOs;

namespace Xdl.Internship.Notifications.SDK.Services
{
    public interface INotifier
    {
        void SendAsync(INotification notification);
    }
}
