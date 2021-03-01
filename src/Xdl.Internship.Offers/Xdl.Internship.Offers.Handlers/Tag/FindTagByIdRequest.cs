using System.Collections.Generic;
using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.SDK.TagDTOs;

namespace Xdl.Internship.Offers.Handlers.Tag
{
    public class FindTagByIdRequest : IRequest<TagMainDTO>
    {
        public FindTagByIdRequest(ObjectId id)
        {
            Id = id;
        }

        public ObjectId Id { get; set; }
    }
}
