using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xdl.Internship.Offers.Models
{
    public class PreOrder : CreationAwareModel
    {
        public ObjectId OfferId { get; set; }

        public ObjectId UserId { get; set; }

        public ObjectId VendorEntityId { get; set; }

        public string Description { get; set; }
    }
}
