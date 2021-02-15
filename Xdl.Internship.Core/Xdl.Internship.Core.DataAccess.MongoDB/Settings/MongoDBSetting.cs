namespace Xdl.Internship.Core.DataAccess.MongoDB.Settings
{
    public class MongoDBSetting : IMongoDBSetting
    {
        public string Host { get; set; }

        public string Port { get; set; }

        public string DatabaseName { get; set; }
    }
}
