using MongoDB.Bson;

namespace Xdl.Internship.Core.Models.MongoDB
{
    public interface IModelBase
    {
        ObjectId Id { get; set; }
    }
}
