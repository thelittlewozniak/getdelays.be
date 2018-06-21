using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDelaysAPI
{
    public class ArrivalDeparture
    {
        public int id { get; set; }
        public double delay { get; set; }
        public string station { get; set; }
        public string vehicle { get; set; }
        public string time { get; set; }
    }
}
