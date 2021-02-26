using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xdl.Internship.Offers.Models;

namespace Xdl.Internship.Offers.DataAccess.Interfaces
{
    public interface IVendorRepository
    {
        Task<ICollection<Vendor>> FindActiveAsync();

        Task<Vendor> GetAllVendors();
    }
}
