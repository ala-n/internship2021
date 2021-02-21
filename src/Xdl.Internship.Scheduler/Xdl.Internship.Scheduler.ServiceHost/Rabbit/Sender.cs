using System;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;
using RabbitMQ.Client;
using Serilog;

namespace Xdl.Internship.Scheduler.ServiceHost.Rabbit
{
    public class Sender : ISend
    {
        private readonly string _hostname;
        private readonly string _password;
        private readonly string _queueName;
        private readonly string _username;
        private IConnection _connection;

        public Sender(IOptions<RabbitMqConfiguration> rabbitMqOptions)
        {
            _queueName = rabbitMqOptions.Value.QueueName;
            _hostname = rabbitMqOptions.Value.Hostname;
            _username = rabbitMqOptions.Value.UserName;
            _password = rabbitMqOptions.Value.Password;
            
            CreateConnection();
        }

        public void Send(object obj)
        {
            if (ConnectionExists())
            {
                using (var channel = _connection.CreateModel())
                {
                    channel.QueueDeclare(queue: _queueName, durable: false, exclusive: false, autoDelete: false, arguments: null);

                    string jsonView = JsonSerializer.Serialize<object>(obj);

                    var body = Encoding.UTF8.GetBytes(jsonView);

                    channel.BasicPublish(exchange: "", routingKey: _queueName, basicProperties: null, body: body);

                    Console.WriteLine(" [x] Published {0} to RabbitMQ", jsonView);
                    Log.Information(" [x] Published {0} to RabbitMQ", jsonView);
                }
            }
        }

        private void CreateConnection()
        {
            try
            {
                var factory = new ConnectionFactory
                {
                    HostName = _hostname,
                    UserName = _username,
                    Password = _password
                };
                _connection = factory.CreateConnection();
            }
            catch (Exception ex)
            {
                Log.Information($"Could not create connection: {ex.Message}");
            }
        }

        private bool ConnectionExists()
        {
            if (_connection != null)
            {
                return true;
            }

            CreateConnection();

            return _connection != null;
        }

    }
}
