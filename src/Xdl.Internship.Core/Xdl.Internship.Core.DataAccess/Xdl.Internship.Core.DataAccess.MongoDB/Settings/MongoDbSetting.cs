using System;
using System.Collections.Generic;
using System.Text;

namespace Xdl.Internship.Core.DataAccess.MongoDB.Settings
{
    public class MongoDbSetting : IMongoDbSetting
    {
        public string DatabaseName { get; set; }
        public string ConnectionString { get; set; }
    }
}
