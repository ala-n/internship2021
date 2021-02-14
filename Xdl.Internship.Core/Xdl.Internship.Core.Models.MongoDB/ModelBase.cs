using MongoDB.Bson;

namespace Xdl.Internship.Core.Models.MongoDB
{
    public class ModelBase : IModelBase
    {
        public ObjectId Id { get; set; }
    }
}
