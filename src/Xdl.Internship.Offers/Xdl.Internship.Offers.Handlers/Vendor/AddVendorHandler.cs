using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.DataAccess.Repositories;
using Xdl.Internship.Offers.SDK.VendorDTOs;

namespace Xdl.Internship.Offers.Handlers.Vendor
{
    public class AddVendorHandler : IRequestHandler<AddVendorRequest, Models.Vendor>
    {
        private readonly IVendorRepository _vendorRepository;
        private readonly IMapper _mapper;

        public AddVendorHandler(IVendorRepository vendorRepository, IMapper mapper)
        {
            _vendorRepository = vendorRepository;
            _mapper = mapper;
        }

        public async Task<Models.Vendor> Handle(AddVendorRequest request, CancellationToken cancellationToken)
        {
            var result = new Models.Vendor();
            result.CreatedAt = DateTime.Now;
            result.Rate = 0;
            result.Name = request.Name;
            result.Title = request.Title;
            result.Website = request.Website;
            result.Description = request.Description;
            result.IsActive = request.IsActive;
            result.CreatedBy = request.CreatedBy;
            return await _vendorRepository.AddVendor(result);
        }
    }
}
