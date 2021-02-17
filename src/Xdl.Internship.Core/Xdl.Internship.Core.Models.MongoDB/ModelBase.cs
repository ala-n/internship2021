using MongoDB.Bson;

namespace Xdl.Internship.Core.Models.MongoDB
{
    public abstract class ModelBase : IModel
    {
        public ObjectId Id { get; set; }
    }
}
