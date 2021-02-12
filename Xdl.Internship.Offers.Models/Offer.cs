using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Offer : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string[] PhotoUrl { get; set; }
        public string PromoCode { get; set; }
        public string Discount { get; set; }
        public DateTime DateStart { get; set; }
        public DateTime DateEnd { get; set; }
        public ObjectId VendorId { get; set; }
        public TagModel[] Tags { get; set; }
        public int NumberOfUses { get; set; }
        public int NumberOfViews { get; set; }
    }
}
