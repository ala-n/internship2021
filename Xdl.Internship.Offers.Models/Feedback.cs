using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Feedback : BaseModel
    {
        public ObjectId OfferId { get; set; }
        public ObjectId UserId { get; set; }
        public int Rate { get; set; }
    }
}
