using System;
using MongoDB.Bson;
using Xdl.Internship.Offers.Models;

namespace Xdl.Internship.Offers.DTOs.VendorEntity
{
    public class VendorEntityMapDTO
    {
        public ObjectId Id { get; set; }

        public double[] Location { get; set; }

        public Adress Adress { get; set; }

        public string Phone { get; set; }

        public string VendorName { get; set; }
    }
}
