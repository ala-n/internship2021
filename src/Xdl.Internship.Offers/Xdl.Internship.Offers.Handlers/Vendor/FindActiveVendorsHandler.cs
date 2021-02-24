using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.DataAccess.Repositories;
using Xdl.Internship.Offers.DTOs.VendorDTOs;

namespace Xdl.Internship.Offers.Handlers.Vendor
{
    public class FindActiveVendorsHandler : IRequestHandler<FindActiveVendorsRequest, ICollection<VendorDTO>>
    {
        private readonly IVendorRepository _vendorRepository;

        public FindActiveVendorsHandler(VendorRepository vendorRepository)
        {
            _vendorRepository = vendorRepository;
        }

        public async Task<ICollection<VendorDTO>> Handle(FindActiveVendorsRequest request, CancellationToken cancellationToken)
        {
            var vendors = await _vendorRepository.FindActiveAsync();
            var vendorDTO = new List<VendorDTO> { };

            foreach (var vendor in vendors)
            {
                vendorDTO.Add(new VendorDTO(vendor));
            }

            return vendorDTO;
        }
    }
}
