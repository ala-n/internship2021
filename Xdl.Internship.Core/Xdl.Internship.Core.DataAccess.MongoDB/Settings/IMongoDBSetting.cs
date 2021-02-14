namespace Xdl.Internship.Core.DataAccess.MongoDB
{
    public interface IMongoDBSetting
    {
        string SectionName { get; set; }

        string HostKeyName { get; set; }

        string PortKeyName { get; set; }

        string DatabaseName { get; set; }
    }
}
