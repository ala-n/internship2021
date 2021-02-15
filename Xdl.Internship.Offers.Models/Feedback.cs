﻿using MongoDB.Bson;
using Xdl.Internship.Core.Models.MongoDB;

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
