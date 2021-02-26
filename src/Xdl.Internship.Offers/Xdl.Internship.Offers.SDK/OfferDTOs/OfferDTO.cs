﻿using System;
using MongoDB.Bson;

namespace Xdl.Internship.Offers.SDK.OfferDTOs
{
    public class OfferDTO
    {
        public ObjectId Id { get; set; }

        public string CreatedBy { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public string UpdatedBy { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string[] PhotoUrl { get; set; }

        public string PromoCode { get; set; }

        public string Discount { get; set; }

        public DateTime DateStart { get; set; }

        public DateTime DateEnd { get; set; }

        public ObjectId VendorId { get; set; }

        public ObjectId[] Tags { get; set; }

        public int NumberOfUses { get; set; }

        public int NumberOfViews { get; set; }

        public double Rate { get; set; }

        public bool IsActive { get; set; }
    }
}
