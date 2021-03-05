using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Bson;
using Xdl.Internship.Core.DataAccess.MongoDB.Repositories;
using Xdl.Internship.Offers.Models;

namespace Xdl.Internship.Offers.DataAccess.Interfaces
{
    public interface IOfferRepository : IMongoRepository<Offer>
    {
        Task<ICollection<Offer>> FindAsync(bool includeInactive, CancellationToken cancellationToken = default);

        Task<ICollection<Offer>> FindByVendorIdAsync(ObjectId vendorId, CancellationToken cancellationToken = default);

        Task<ICollection<Offer>> FindByVendorEntityIdAsync(ObjectId vendorEntityId, bool includeInactive = false, CancellationToken cancellationToken = default);
    }
}
