using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.DataAccess.Repositories;
using Xdl.Internship.Offers.SDK.TagDTOs;

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
            var topTags = tags.OrderByDescending(t => t.UsesByUser).Take(1);

            var tagDTO = new List<TagDTO> { };

            foreach (var tag in topTags)
            {
                tagDTO.Add(_mapper.Map<TagDTO>(tag));
            }

            return tagDTO;
        }
    }
}
