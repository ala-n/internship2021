using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xdl.Internship.Offers.Models
{
    public class VendorEntity :  AuditableModelBase
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
