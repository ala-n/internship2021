using System;
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
    public class FindAllTagsStatisticsHandler : IRequestHandler<FindAllTagsStatisticsRequest, ICollection<TagStatisticsDTO>>
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public FindAllTagsStatisticsHandler(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task<ICollection<TagStatisticsDTO>> Handle(FindAllTagsStatisticsRequest request, CancellationToken cancellationToken)
        {
            var tags = await _tagRepository.FindAsync(request.IncludeInactive);
            var allTags = tags.GroupBy(t => t.Name).Select(t => t.FirstOrDefault()).OrderBy(t => t.Name);

            var tagDTO = new List<TagStatisticsDTO> { };

            foreach (var tag in allTags)
            {
                tagDTO.Add(_mapper.Map<TagStatisticsDTO>(tag));
            }

            return tagDTO;
        }
    }
}