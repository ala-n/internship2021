using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;

namespace Xdl.Internship.Core.Models.MongoDB
{
    public abstract class AuditableModelBase : ModelBase, ICreationAwareModel, IUpdationAwareModel
    {
        public ObjectId CreatedBy { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public ObjectId UpdatedBy { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}
