using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Text;

namespace Xdl.Internship.Core.DataAccess.MongoDB.Entities
{
    public abstract class Document : IDocument
    {
        public ObjectId Id { get; set; }
    }
}
