using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDelaysAPI
{
    public class Train
    {
        public string vehicle { get; set; }
        public List<Stop> stops { get; set; }
        public Train()
        {
            stops = new List<Stop>();
        }
    }
}
