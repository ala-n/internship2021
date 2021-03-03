using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Bson;
using Xdl.Internship.Core.DataAccess.MongoDB.Repositories;
using Xdl.Internship.Offers.Models;

namespace Xdl.Internship.Offers.DataAccess.Interfaces
{
    public interface IVendorRepository : IMongoRepository<Vendor>
    {
        Task<ICollection<Vendor>> FindAsync(bool includeInactive, CancellationToken cancellationToken = default);

        Task<ICollection<Vendor>> FindByIdsAsync(ICollection<ObjectId> ids, CancellationToken cancellationToken = default);
    }
}
