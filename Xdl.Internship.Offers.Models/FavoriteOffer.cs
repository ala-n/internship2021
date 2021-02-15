using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Xdl.Internship.Offers.Models
{
    public class FavoriteOffer : CreationAwareModel
    {
        public ObjectId OfferId { get; set; }

        public ObjectId UserId { get; set; }

    }
}
