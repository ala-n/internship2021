using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using Xdl.Internship.Offers.Models;

namespace Xdl.Internship.Offers.DataAccess.Interfaces
{
    public interface IOfferRepository
    {
        Task<ICollection<Offer>> FindActiveAsync();

        Task<ICollection<Offer>> FindOffersByVendorId(ObjectId vendorId);

        Task<ICollection<Offer>> FindOffersByCityId(ObjectId cityId);

        Task<Offer> FindOfferById(ObjectId offerId);

        Task<ICollection<Offer>> FindOfferByVendorEntityId(ObjectId vendorEntityId);
    }
}
