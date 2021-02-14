using System;
using MongoDB.Bson;

namespace Xdl.Internship.Core.Models.MongoDB
{
    public interface ICreationAwareModel
    {
        ObjectId CreatedBy { get; set; }

        DateTimeOffset CreatedAt { get; set; }
    }

    public abstract class CreationAwareModel : ICreationAwareModel
    {
        public ObjectId CreatedBy { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}
