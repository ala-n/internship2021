using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using Xdl.Internship.Offers.Models;

namespace Xdl.Internship.Offers.DataAccess.Interfaces
{
    public interface IOfferRepository
    {
        Task<ICollection<Offer>> FindActiveAsync();

        Task<ICollection<Offer>> GetOffersByVendorId(ObjectId vendorId);

        Task<ICollection<Offer>> GetOffersByCityId(ObjectId cityId);

        Task<ICollection<Offer>> GetOfferById(ObjectId offerId);
    }
}
