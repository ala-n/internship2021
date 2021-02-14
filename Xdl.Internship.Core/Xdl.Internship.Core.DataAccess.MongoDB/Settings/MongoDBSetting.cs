namespace Xdl.Internship.Core.DataAccess.MongoDB.Settings
{
    public class MongoDBSetting : IMongoDBSetting
    {
        public string SectionName { get; set; }
        public string HostKeyName { get; set; }
        public string PortKeyName { get; set; }
        public string DatabaseName { get; set; }
    }
}
