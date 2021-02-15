using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xdl.Internship.Offers.Models
{
    public class Vendor : AuditableModelBase
    {
	public string Name { get; set; }
	
	public string Title { get; set; }
	
	public string Website { get; set; }
	
	public string Description { get; set; }
	
	public double Rate { get; set; }
	
	public bool IsActive { get; set; }
    }
}
