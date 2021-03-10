using System;
using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.SDK.Identity;
using Xdl.Internship.Offers.SDK.TagDTOs;

namespace Xdl.Internship.Offers.Handlers.Tag
{
    public class RestoreTagRequest : IRequest<TagDTO>
    {
        public ObjectId Id { get; }

        public RestoreTagDTO TagDTO { get; }

        public CreateIdentity Identity;

        public RestoreTagRequest(ObjectId id, RestoreTagDTO tagDTO, CreateIdentity identity)
        {
            Id = id;
            TagDTO = tagDTO;
            Identity = identity;
        }
    }
}