using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.SDK.OfferDTOs;

namespace Xdl.Internship.Offers.Handlers.Offer
{
    public class FindOffersByVendorIdWithVendorInfoHandler : IRequestHandler<FindOffersByVendorIdWithVendorInfoRequest, ICollection<OfferWithVendorNameDTO>>
    {
        private readonly IOfferRepository _offerRepository;
        private readonly IVendorEntityRepository _vendorEntityRepository;
        private readonly IVendorRepository _vendorRepository;
        private readonly IMapper _mapper;

        public FindOffersByVendorIdWithVendorInfoHandler(IOfferRepository offerRepository, IVendorEntityRepository vendorEntityRepository, IVendorRepository vendorRepository, IMapper mapper)
        {
            _offerRepository = offerRepository;
            _vendorEntityRepository = vendorEntityRepository;
            _vendorRepository = vendorRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<OfferWithVendorNameDTO>> Handle(FindOffersByVendorIdWithVendorInfoRequest request, CancellationToken cancellationToken)
        {
            // TO-DO: optimize
            var vendor = await _vendorRepository.FindByIdAsync(request.VendorId);
            var entities = await _vendorEntityRepository.FindByVendorIdAsync(request.VendorId, !request.IncludeInactive);

            var offersTask = new List<Task<ICollection<Models.Offer>>>();
            foreach (var entity in entities)
            {
                offersTask.Add(_offerRepository.FindByVendorEntityIdAsync(entity.Id));
            }

            // Flattening and filtering to distinct
            var offersRaw = await Task.WhenAll(offersTask);
            ICollection<Models.Offer> offers = offersRaw.SelectMany(o => o).Distinct().ToList();

            ICollection<OfferWithVendorNameDTO> result = new List<OfferWithVendorNameDTO>();
            foreach (var offer in offers)
            {
                var offerDTO = _mapper.Map<OfferWithVendorNameDTO>(offer);
                result.Add(_mapper.Map(vendor, offerDTO));
            }

            return result;
        }
    }
}
