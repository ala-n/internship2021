namespace Xdl.Internship.Core.DataAccess.MongoDB
{
    public class MongoDBSetting : IMongoDBSetting
    {
        public string HostKeyName { get; set; }

        public string PortKeyName { get; set; }

        public string DatabaseName { get; set; }
    }
}
