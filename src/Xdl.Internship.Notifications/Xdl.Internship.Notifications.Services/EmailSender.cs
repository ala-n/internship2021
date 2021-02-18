using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Serilog;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Text.Json;
using Xdl.Internship.Notifications.SDK.DTOs;

namespace Xdl.Internship.Notifications.Services
{
    public class EmailSender : BackgroundService
    {
        private IConnection _connection;
        private IModel _channel;

        public EmailSender()
        {
            InitRabbitMQ();
        }

        private void InitRabbitMQ()
        {
            var factory = new ConnectionFactory
            {
                HostName = "my-rabbit",
                UserName = "guest",
                Password = "guest",
                Port = AmqpTcpEndpoint.UseDefaultPort,
                VirtualHost = "/",
                RequestedHeartbeat = new TimeSpan(60),
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare("notifications.exchange", ExchangeType.Topic);
            _channel.QueueDeclare("notifications.queue.log", false, false, false, null);
            _channel.QueueBind("notifications.queue.log", "notifications.exchange", "notifications.queue.*", null);
            _channel.BasicQos(0, 1, false);
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            stoppingToken.ThrowIfCancellationRequested();

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (ch, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = JsonSerializer.Deserialize<EmailMessage>(body);
                HandleMessage(message);
            };

            _channel.BasicConsume("notifications.queue.log", false, consumer);
            Log.Logger.Information("Message has recieved");
            return Task.CompletedTask;
        }

        private void HandleMessage(EmailMessage emailMessage)
        {
            try
            {
                EmailService emailService = new EmailService();
                emailService.SendEmail(emailMessage);
                Log.Logger.Information("Message was sent");
            }
            catch (Exception ex)
            {
                Log.Logger.Information(ex.Message);
            }
        }
        public override void Dispose()
        {
            _channel.Close();
            _connection.Close();
            base.Dispose();
        }

    }
}