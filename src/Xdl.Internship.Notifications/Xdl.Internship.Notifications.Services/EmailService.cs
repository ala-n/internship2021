using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Text;
using Xdl.Internship.Notifications.SDK.DTOs;
using Xdl.Internship.Notifications.SDK.Services;

namespace Xdl.Internship.Notifications.Services
{
    public class EmailService : INotifier
    {
        private readonly string _address;
        private readonly int _port;
        private readonly string _password;
        private readonly string _senderEmail;
        private readonly string _senderName;

        public EmailService(IOptions<SMTPConfiguration> SMTPOptions)
        {
            _address = SMTPOptions.Value.Address;
            _port = SMTPOptions.Value.Port;
            _password = SMTPOptions.Value.Password;
            _senderEmail = SMTPOptions.Value.SenderEmail;
            _senderName = SMTPOptions.Value.SenderName;
        }

        public void SendAsync(INotification notification)
        {
            throw new NotImplementedException();
        }

        public void SendEmail(EmailMessage message)
        {
            var emailMessage = new MimeMessage();

            emailMessage.From.Add(new MailboxAddress(_senderName, _senderEmail));
            emailMessage.To.Add(new MailboxAddress(string.Empty, message.To));
            emailMessage.Subject = message.Subject;
            emailMessage.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = message.Content,
            };

            using (var client = new SmtpClient())
            {
                client.Connect(_address, _port, false);
                client.Authenticate(_senderEmail, _password);
                client.Send(emailMessage);
                client.Disconnect(true);
            }
        }
    }
}
