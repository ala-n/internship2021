using System;
using MongoDB.Bson;
using Xdl.Internship.Offers.Models;

namespace Xdl.Internship.Offers.DTOs.VendorDTOs
{
    public class VendorDTO
    {
        public VendorDTO()
        {
        }

        public VendorDTO(Vendor vendor)
        {
            Id = vendor.Id;
            CreatedBy = vendor.CreatedBy;
            CreatedAt = vendor.CreatedAt;
            UpdatedBy = vendor.UpdatedBy;
            UpdatedAt = vendor.UpdatedAt;
            Name = vendor.Name;
            Title = vendor.Title;
            Website = vendor.Website;
            Description = vendor.Description;
            Rate = vendor.Rate;
            IsActive = vendor.IsActive;
        }

        public ObjectId Id { get; set; }

        public string CreatedBy { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public string UpdatedBy { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }

        public string Name { get; set; }

        public string Title { get; set; }

        public string Website { get; set; }

        public string Description { get; set; }

        public double Rate { get; set; }

        public bool IsActive { get; set; }
    }
}
