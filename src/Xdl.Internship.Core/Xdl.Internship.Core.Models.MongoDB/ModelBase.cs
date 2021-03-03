using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Xdl.Internship.Core.Models.MongoDB
{
    public abstract class ModelBase : IModel
    {
        [BsonId]
        public ObjectId Id { get; set; }
    }
}
