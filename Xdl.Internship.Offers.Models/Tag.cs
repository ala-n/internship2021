using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Tag : BaseModel
    {
        public string Name { get; set; }
        public int UsesByUser { get; set; }
        public int UsesByVendor { get; set; }
    }
}
