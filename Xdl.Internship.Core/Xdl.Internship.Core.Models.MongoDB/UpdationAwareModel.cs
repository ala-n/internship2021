﻿using System;
using MongoDB.Bson;

namespace Xdl.Internship.Core.Models.MongoDb
{
    public interface IUpdationAwareModel
    {
        ObjectId UpdatedBy { get; set; }

        DateTimeOffset UpdatedAt { get; set; }
    }

    class UpdationAwareModel : IUpdationAwareModel
    {
        public ObjectId UpdatedBy { get; set; }

        public DateTimeOffset UpdatedAt { get; set; }
    }
}
