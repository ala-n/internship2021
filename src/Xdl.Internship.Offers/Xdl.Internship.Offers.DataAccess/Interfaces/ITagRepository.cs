using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MongoDB.Bson;
using Xdl.Internship.Offers.Models;

namespace Xdl.Internship.Offers.DataAccess.Interfaces
{
    public interface ITagRepository
    {
        Task<ICollection<Tag>> FindTopTagsAsync();

        Task<Tag> FindTagById(ObjectId tagId);

        Task<ICollection<Tag>> FindAllTagsAsync();

        Task InsertTagAsync(Tag tag, CancellationToken cancellationToken = default);

        Task DeleteTagAsync(ObjectId tagId, CancellationToken cancellationToken = default);
    }
}
