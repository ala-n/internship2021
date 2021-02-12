using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Vendor : BaseModel
    {
	public string Name { get; set; }
	public string Title { get; set; }
	public string Website { get; set; }
	public string Description { get; set; 
    }
}
