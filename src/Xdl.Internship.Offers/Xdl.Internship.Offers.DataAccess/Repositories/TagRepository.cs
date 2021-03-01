﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Bson;
using Xdl.Internship.Core.DataAccess.MongoDB.CollectionProviders;
using Xdl.Internship.Core.DataAccess.MongoDB.Repositories;
using Xdl.Internship.Offers.DataAccess.Interfaces;
using Xdl.Internship.Offers.Models;

namespace Xdl.Internship.Offers.DataAccess.Repositories
{
    public class TagRepository : MongoRepositoryBase<Tag>, ITagRepository
    {
        public TagRepository(ICollectionProvider collectionProvider)
            : base(collectionProvider)
        {
        }

        public async Task<ICollection<Tag>> FindTopTagsAsync()
        {
            Expression<Func<Tag, bool>> filter = (tag) => tag.UsesByUser > 0;

            return await FindAsync(filter);
        }

        public Task<Tag> FindTagById(ObjectId tagId)
        {
            return FindByIdAsync(tagId);
        }
    }
}
