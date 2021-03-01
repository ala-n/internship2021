using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Bson;
using Xdl.Internship.Offers.Models;

namespace Xdl.Internship.Offers.DataAccess.Interfaces
{
    public interface IVendorRepository
    {
        Task<Vendor> FindByIdAsync(ObjectId id, CancellationToken cancellationToken = default);

        Task<ICollection<Vendor>> FindActiveAsync(CancellationToken cancellationToken = default);

        Task<ICollection<Vendor>> FindByIdsAsync(ICollection<ObjectId> ids, CancellationToken cancellationToken = default);

        Task<Vendor> AddVendor(Vendor vendor, CancellationToken cancellationToken = default);

        Task<ICollection<Vendor>> GetAllAdminVendors(CancellationToken cancellationToken = default);

        Task<Vendor> FindAdminVendorById(ObjectId id, CancellationToken cancellationToken = default);
    }
}
