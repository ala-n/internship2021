using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.SDK.TagDTOs;

namespace Xdl.Internship.Offers.Handlers.Tag
{
    public class RestoreTagHandler : IRequestHandler<RestoreTagRequest, TagDTO>
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public RestoreTagHandler(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task<TagDTO> Handle(RestoreTagRequest request, CancellationToken cancellationToken)
        {
            var tag = await _tagRepository.FindByIdAsync(request.Id);
            tag.IsDeleted = false;

            await _tagRepository.ReplaceOneAsync(tag);

            return _mapper.Map<TagDTO>(tag);
        }
    }
}