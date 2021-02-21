using System;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Serilog;
using Xdl.Internship.Notifications.SDK.DTOs;

namespace Xdl.Internship.Notifications.Services
{
    public class RabbitMQProvider : BackgroundService
    {
        private IModel _channel;
        private readonly string _hostName;
        private readonly string _userName;
        private readonly string _password;
        private readonly string _exchangeName;
        private readonly string _queueName;
        private readonly string _virtualHost;
        private readonly TimeSpan _requestedHeartbeat;
        private readonly EmailService _emailService;
        private readonly ILogger _serilog;
        private IConnection _connection;

        public RabbitMQProvider(IOptions<RabbitMqConfiguration> rabbitMqOptions, EmailService emailService, ILogger serilog)
        {
            _hostName = rabbitMqOptions.Value.HostName;
            _userName = rabbitMqOptions.Value.UserName;
            _password = rabbitMqOptions.Value.Password;
            _queueName = rabbitMqOptions.Value.QueueName;
            _exchangeName = rabbitMqOptions.Value.ExchangeName;
            _virtualHost = rabbitMqOptions.Value.VirtualHost;
            _requestedHeartbeat = rabbitMqOptions.Value.RequestedHeartbeat;
            _emailService = emailService;
            _serilog = serilog;
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

            _channel.BasicConsume(_queueName, false, consumer);
            _serilog.Information("Message has recieved");
            return Task.CompletedTask;
        }

        public override Task StartAsync(CancellationToken cancellationToken)
        {
            var factory = new ConnectionFactory
            {
                HostName = _hostName,
                UserName = _userName,
                Password = _password,
                VirtualHost = _virtualHost,
                RequestedHeartbeat = _requestedHeartbeat,
            };
            _connection = factory.CreateConnection();
            _channel = _connection.CreateModel();

            _channel.ExchangeDeclare(_exchangeName, ExchangeType.Topic);
            _channel.QueueDeclare(_queueName, false, false, false, null);
            _channel.QueueBind(_queueName, _exchangeName, _queueName, null);
            _channel.BasicQos(0, 1, false);
            return Task.CompletedTask;
        }

        private void HandleMessage(EmailMessage emailMessage)
        {
            try
            {
                _emailService.SendEmail(emailMessage);
                _serilog.Information("Message was sent to ", emailMessage.To);
            }
            catch (Exception ex)
            {
                _serilog.Information(ex.Message);
            }
        }
    }
}
