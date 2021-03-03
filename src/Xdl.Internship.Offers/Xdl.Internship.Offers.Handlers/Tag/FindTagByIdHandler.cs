using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.DataAccess.Repositories;
using Xdl.Internship.Offers.SDK.TagDTOs;

namespace Xdl.Internship.Offers.Handlers.Tag
{
    public class FindTagByIdHandler : IRequestHandler<FindTagByIdRequest, TagMainDTO>
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public FindTagByIdHandler(TagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task<TagMainDTO> Handle(FindTagByIdRequest request, CancellationToken cancellationToken)
        {
            return _mapper.Map<TagMainDTO>(await _tagRepository.FindByIdAsync(request.Id));
        }
    }
}
