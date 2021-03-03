using MediatR;
using Xdl.Internship.Offers.SDK.VendorDTOs;

namespace Xdl.Internship.Offers.Handlers.Vendor
{
    public class AddVendorRequest : IRequest<Models.Vendor>
    {
        public AddVendorRequest(string name, string title, string website, string description, bool isActive, string createdBy)
        {
            Name = name;
            Title = title;
            Website = website;
            Description = description;
            IsActive = isActive;
            CreatedBy = createdBy;
        }

        public string Name { get; }

        public string Title { get; }

        public string Website { get; }

        public string Description { get; }

        public bool IsActive { get; }

        public string CreatedBy { get; }
    }
}