using System;

namespace Xdl.Internship.Core.Models.MongoDB
{
    public interface IUpdationAwareModel
    {
        string UpdatedBy { get; set; }

        DateTimeOffset UpdatedAt { get; set; }
    }

    public abstract class UpdationAwareModel : ModelBase, IUpdationAwareModel
    {
        public string UpdatedBy { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}
