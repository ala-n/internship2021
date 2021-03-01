using System;
using System.Collections.Generic;
using MongoDB.Bson;
using Xdl.Internship.Core.Models.MongoDB;

namespace Xdl.Internship.Offers.Models
{
    public class Offer : AuditableModelBase
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public string[] PhotoUrl { get; set; }

        public string PromoCode { get; set; }

        public string Discount { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        public ICollection<ObjectId> VendorEntitiesId { get; set; }

        public ObjectId[] Tags { get; set; }

        public int NumberOfUses { get; set; }

        public int NumberOfViews { get; set; }

        public double Rate { get; set; }

        public bool IsActive { get; set; }
    }
}
