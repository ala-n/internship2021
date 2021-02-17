using MongoDB.Bson;

namespace Xdl.Internship.Core.Models.MongoDB
{
    public abstract class ModelBase : IModelBase
    {
        public ObjectId Id { get; set; }
    }
}
