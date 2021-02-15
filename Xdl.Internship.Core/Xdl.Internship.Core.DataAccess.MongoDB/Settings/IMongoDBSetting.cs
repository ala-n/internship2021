namespace Xdl.Internship.Core.DataAccess.MongoDB
{
    public interface IMongoDBSetting
    {
        string Host { get; set; }

        string Port { get; set; }

        string DatabaseName { get; set; }
    }
}
