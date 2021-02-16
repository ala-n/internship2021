using System;

namespace Xdl.Internship.Core.Models.MongoDB
{
    public interface ICreationAwareModel
    {
        string CreatedBy { get; set; }

        DateTimeOffset CreatedAt { get; set; }
    }

    public abstract class CreationAwareModel : ModelBase, ICreationAwareModel
    {
        public string CreatedBy { get; set; }

        public DateTimeOffset CreatedAt { get; set; }
    }
}
