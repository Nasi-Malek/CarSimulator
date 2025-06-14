using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Services.ApiService
{
    public class Result
    {
        public Name Name { get; set; }
        public string Gender { get; set; }
        public Location Location { get; set; }
    }
}
