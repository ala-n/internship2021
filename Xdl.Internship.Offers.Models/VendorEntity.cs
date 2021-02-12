using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class VendorEntity : BaseModel
    {
        public LocationModel Location { get; set; }
        public Adress Adress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public ObjectId VendorId { get; set; }
    }
}
