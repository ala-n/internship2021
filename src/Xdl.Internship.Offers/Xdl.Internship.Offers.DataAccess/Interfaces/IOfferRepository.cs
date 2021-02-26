using System.Collections.Generic;
using System.Threading.Tasks;
using Xdl.Internship.Offers.Models;

namespace Xdl.Internship.Offers.DataAccess.Interfaces
{
    public interface IOfferRepository
    {
        Task<ICollection<Offer>> FindActiveAsync();

        Task<Offer> GetAllOffers();
    }
}
