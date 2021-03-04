using System;
using System.Threading;
using System.Threading.Tasks;
using Xdl.Internship.Offers.Models;

namespace Xdl.Internship.Offers.DataAccess.Interfaces
{
    public interface IFeedbackRepository
    {
        Task InsertFeedbackAsync(Feedback feedback, CancellationToken cancellationToken = default);
    }
}
