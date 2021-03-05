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
    public class FindTopTagsHandler : IRequestHandler<FindTopTagsRequest, ICollection<TagMainDTO>>
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public FindTopTagsHandler(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<TagMainDTO>> Handle(FindTopTagsRequest request, CancellationToken cancellationToken)
        {
            var tags = await _tagRepository.FindTopTagsAsync();
            var topTags = tags.GroupBy(t => t.Name).Select(t => t.FirstOrDefault()).OrderByDescending(t => t.UsesByUser).Take(20);

            var tagDTO = new List<TagMainDTO> { };

            foreach (var tag in topTags)
            {
                tagDTO.Add(_mapper.Map<TagMainDTO>(tag));
            }

            return tagDTO;
        }
    }
}
