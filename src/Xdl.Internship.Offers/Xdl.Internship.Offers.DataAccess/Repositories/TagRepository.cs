using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
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

        public Task<ICollection<Tag>> FindAsync(bool includeInactive, CancellationToken cancellationToken = default)
        {
            Expression<Func<Tag, bool>> filter = (v) => (includeInactive || v.IsDeleted == false) && v.Name.Length > 0;
            return FindAsync(filter, cancellationToken = default);
        }
    }
}
