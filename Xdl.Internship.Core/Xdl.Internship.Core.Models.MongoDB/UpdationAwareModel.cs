using System;
using MongoDB.Bson;

namespace Xdl.Internship.Core.Models.MongoDB
{
    public interface IUpdationAwareModel
    {
        ObjectId UpdatedBy { get; set; }

        DateTimeOffset UpdatedAt { get; set; }
    }

    public abstract class UpdationAwareModel : IUpdationAwareModel
    {
        public ObjectId UpdatedBy { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}
