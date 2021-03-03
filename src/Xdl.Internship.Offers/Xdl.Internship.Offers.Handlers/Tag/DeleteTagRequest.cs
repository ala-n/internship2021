using System;
using MediatR;
using MongoDB.Bson;

namespace Xdl.Internship.Offers.Handlers.Tag
{
    public class DeleteTagRequest : IRequest
    {
        public ObjectId Id { get; }

        public DeleteTagRequest(ObjectId id)
        {
            Id = id;
        }
    }
}
