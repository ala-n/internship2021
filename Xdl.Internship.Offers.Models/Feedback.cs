using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xdl.Internship.Offers.Models
{
    public class Feedback :  AuditableModelBase
    {
        public ObjectId OfferId { get; set; }
        
        public ObjectId UserId { get; set; }
        
        public ObjectId VendorEntityId { get; set; }
        
        public int Rate { get; set; }
    }
}
