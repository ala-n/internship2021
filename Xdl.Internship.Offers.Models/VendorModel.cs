using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class VendorModel : BaseModel
    {
		public string Name { get; set; }
		public string Title { get; set; }
		public string Website { get; set; }
		public string Description { get; set; }
		public DateTime CreatedAt { get; set; }
		public DateTime UpdatedAt { get; set; }
		public ObjectId CreatedBy { get; set; }
		public ObjectId UpdatedBy { get; set; }
		public bool IsActive { get; set; }
	}
}
