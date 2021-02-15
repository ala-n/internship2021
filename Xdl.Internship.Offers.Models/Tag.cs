using Xdl.Internship.Core.Models.MongoDB;

namespace Xdl.Internship.Offers.Models
{
    public class Tag : AuditableModelBase
    {
        public string Name { get; set; }

        public int UsesByUser { get; set; }

        public int UsesByVendor { get; set; }

        public bool IsDeleted { get; set; }
    }
}
