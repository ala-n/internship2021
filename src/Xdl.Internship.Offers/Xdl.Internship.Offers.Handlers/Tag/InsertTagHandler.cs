using System;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.DataAccess.Repositories;
using Xdl.Internship.Offers.Models;
using Xdl.Internship.Offers.SDK.TagDTOs;

namespace Xdl.Internship.Offers.Handlers.Tag
{
    public class InsertTagHandler : IRequestHandler<InsertTagRequest>
    {
        private readonly ITagRepository _tagRepository;
        private readonly IMapper _mapper;

        public InsertTagHandler(TagRepository tagRepository, IMapper mapper)
        {
            _tagRepository = tagRepository;
            _mapper = mapper;
        }

        async Task<Unit> IRequestHandler<InsertTagRequest, Unit>.Handle(InsertTagRequest request, CancellationToken cancellationToken)
        {
            Console.WriteLine(request.TagDTO + "  " + request.TagDTO.Name);
            var entity = _mapper.Map<Models.Tag>(request.TagDTO);
            Console.WriteLine("text rrr " + entity);
            await _tagRepository.InsertTagAsync(entity);

            return Unit.Value;
        }
    }
}