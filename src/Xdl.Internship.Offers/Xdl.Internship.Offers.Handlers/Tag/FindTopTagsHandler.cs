using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.DataAccess.Repositories;
using Xdl.Internship.Offers.DTOs.TagDTOs;

namespace Xdl.Internship.Offers.Handlers.Tag
{
    public class FindTopTagsHandler : IRequestHandler<FindTopTagsRequest, ICollection<TagDTO>>
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public FindTopTagsHandler(TagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<TagDTO>> Handle(FindTopTagsRequest request, CancellationToken cancellationToken)
        {
            var tags = await _tagRepository.FindTopTagsAsync();
            var tagDTO = new List<TagDTO> { };

            foreach (var tag in tags)
            {
                tagDTO.Add(_mapper.Map<TagDTO>(tag));
            }

            return tagDTO;
        }
    }
}
