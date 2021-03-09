using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.DataAccess.Repositories;

namespace Xdl.Internship.Offers.Handlers.Tag
{
    public class DeleteTagHandler : IRequestHandler<DeleteTagRequest>
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public DeleteTagHandler(ITagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteTagRequest request, CancellationToken cancellationToken)
        {
            var tag = await _tagRepository.FindByIdAsync(request.Id);
            tag.IsDeleted = true;
            tag = _mapper.Map(request.Identity, tag);

            await _tagRepository.ReplaceOneAsync(tag);

            return Unit.Value;
        }
    }
}
