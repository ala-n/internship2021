using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Bson;
using Xdl.Internship.Core.DataAccess.MongoDB.Repositories;
using Xdl.Internship.Offers.Models;

namespace Xdl.Internship.Offers.DataAccess.Interfaces
{
    public interface IVendorEntityRepository : IMongoRepository<VendorEntity>
    {
        // READ
        Task<VendorEntity> FindOneByLocationAsync(double[] location, CancellationToken cancellationToken = default);

        Task<ICollection<VendorEntity>> FindAsync(bool includeInactive, CancellationToken cancellationToken = default);

        Task<ICollection<VendorEntity>> FindByCityAsync(ObjectId cityId, bool onlyActive, CancellationToken cancellationToken = default);

        Task<ICollection<VendorEntity>> FindByVendorId(ObjectId vendorId, CancellationToken cancellationToken = default);
    }
}
