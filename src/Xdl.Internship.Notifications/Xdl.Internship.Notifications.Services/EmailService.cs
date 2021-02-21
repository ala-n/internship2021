using System;
using System.Collections.Generic;
using System.Text;
using Xdl.Internship.Notifications.SDK.DTOs;
using Xdl.Internship.Notifications.SDK.Services;
using MailKit;
using MimeKit;
using MailKit.Net.Smtp;

namespace Xdl.Internship.Notifications.Services
{
    public class EmailService : INotifier
    {
        public void SendAsync(INotification notification)
        {
        }
        public void SendEmail(EmailMessage emailMes)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress("Администрация сайта", "xdlinternship2021@yandex.by"));
            emailMessage.To.Add(new MailboxAddress(string.Empty, emailMes.To));
            emailMessage.Subject = emailMes.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = emailMes.Content,
            };

            using (var client = new SmtpClient())
            {
                client.Connect("smtp.yandex.ru", 587, false);
                client.Authenticate("xdlinternship2021@yandex.by", "xdl2021t2");
                client.Send(emailMessage);
                client.Disconnect(true);
            }
        }

    }
}
