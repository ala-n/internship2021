using MongoDB.Bson;
using Xdl.Internship.Core.Models.MongoDB;

namespace Xdl.Internship.Offers.Models
{
    public class VendorEntity : AuditableModelBase
    {
        public double[] Location { get; set; }

        public Adress Adress { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public ObjectId VendorId { get; set; }

        public bool IsActive { get; set; }

        public double Rate { get; set; }
    }
}
