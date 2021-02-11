using System;
using System.Collections.Generic;
using System.Text;

namespace Xdl.Internship.Core.DataAccess.MongoDB.Settings
{
    public interface IMongoDbSetting
    {
        string DatabaseName { get; set; }
        string ConnectionString { get; set; }
    }
}
