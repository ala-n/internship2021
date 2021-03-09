using System;
using MediatR;
using MongoDB.Bson;
using Xdl.Internship.Offers.SDK.Identity;

namespace Xdl.Internship.Offers.Handlers.Tag
{
    public class DeleteTagRequest : IRequest
    {
        public ObjectId Id { get; }

        public UpdateIdentity Identity;

        public DeleteTagRequest(ObjectId id, UpdateIdentity identity)
        {
            Id = id;
            Identity = identity;
        }
    }
}
