using System;
using MongoDB.Bson;
using Xdl.Internship.Offers.Models;

namespace Xdl.Internship.Offers.SDK.VendorEntityDTOs
{
    public class VendorEntityDTO
    {
        public ObjectId Id { get; set; }

        public string CreatedBy { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public string UpdatedBy { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public double[] Location { get; set; }

        public Adress Adress { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public ObjectId VendorId { get; set; }

        public bool IsActive { get; set; }

        public double Rate { get; set; }
    }
}
