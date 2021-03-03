using MongoDB.Bson;
using Xdl.Internship.Core.Models.MongoDB;

namespace Xdl.Internship.Offers.Models
{
    public class City : AuditableModelBase
    {
        public string Name { get; set; }

        public bool IsActive { get; set; }
    }
}
