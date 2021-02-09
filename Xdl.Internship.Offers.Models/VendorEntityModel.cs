using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class VendorEntityModel : BaseModel
    {
        public LocationModel Location { get; set; }
        public AdressModel Adress { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public ObjectId VendorId { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public ObjectId CreatedBy { get; set; }
        public ObjectId UpdatedBy { get; set; }
    }
}
