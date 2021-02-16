using System;

namespace Xdl.Internship.Core.Models.MongoDB
{
    public abstract class AuditableModelBase : ModelBase, ICreationAwareModel, IUpdationAwareModel
    {
        public string CreatedBy { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public string UpdatedBy { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}
