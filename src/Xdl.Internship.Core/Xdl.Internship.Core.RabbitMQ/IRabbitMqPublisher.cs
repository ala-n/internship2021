namespace Xdl.Internship.Core.RabbitMQ.SDK
{
    public interface IRabbitMqPublisher
    {
        void Publish(byte[] body);
    }
}
