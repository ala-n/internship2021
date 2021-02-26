using System.Collections.Generic;
using System.Threading.Tasks;
using Xdl.Internship.Offers.Models;

namespace Xdl.Internship.Offers.DataAccess.Interfaces
{
    public interface ITagRepository
    {
        Task<ICollection<Tag>> FindTopTagsAsync();
    }
}
