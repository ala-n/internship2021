using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xdl.Internship.Core.DataAccess.MongoDB.CollectionProviders;
using Xdl.Internship.Core.DataAccess.MongoDB.Repositories;
using Xdl.Internship.Offers.Models;

namespace Xdl.Internship.Offers.DataAccess.Repositories
{
    //public interface IVendorRepository
    //{

    //}

    public class VendorRepository : MongoRepositoryBase<Vendor>
    {
        public VendorRepository(ICollectionProvider collectionProvider)
            : base(collectionProvider)
        {
        }
    }
}
