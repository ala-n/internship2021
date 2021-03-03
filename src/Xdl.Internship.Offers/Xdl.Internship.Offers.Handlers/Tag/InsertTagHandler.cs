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
    public class InsertTagHandler : IRequestHandler<InsertTagRequest, TagDTO>
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public InsertTagHandler(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task<TagDTO> Handle(InsertTagRequest request, CancellationToken cancellationToken)
        {
            var tag = _mapper.Map<Models.Tag>(request.TagDTO);

            await _tagRepository.InsertOneAsync(tag);

            return _mapper.Map<TagDTO>(await _tagRepository.FindByIdAsync(tag.Id));
        }
    }
}