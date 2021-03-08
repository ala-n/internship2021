using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Bson;
using Xdl.Internship.Core.DataAccess.MongoDB.Repositories;
using Xdl.Internship.Offers.Models;

namespace Xdl.Internship.Offers.DataAccess.Interfaces
{
    public interface ITagRepository : IMongoRepository<Tag>
    {
        Task<ICollection<Tag>> FindAsync(bool includeInactive, CancellationToken cancellationToken = default);
    }
}
