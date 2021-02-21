using MongoDB.Bson;

namespace Xdl.Internship.Core.Models.MongoDB
{
    public interface IModel
    {
        ObjectId Id { get; set; }
    }
}
