using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using Xdl.Internship.Offers.Models;

namespace Xdl.Internship.Offers.DataAccess.Interfaces
{
    public interface IVendorRepository
    {
        Task<Vendor> FindByIdAsync(ObjectId id);

        Task<ICollection<Vendor>> FindActiveAsync();

        Task<ICollection<Vendor>> FindByIdsAsync(ICollection<ObjectId> ids);
    }
}
