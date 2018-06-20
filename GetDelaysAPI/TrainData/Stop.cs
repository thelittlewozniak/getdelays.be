using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GetDelaysAPI
{
    public class Stop
    {
        public int id { get; set; }
        public string station { get; set; }
        public int delay { get; set; }
        public string platform { get; set; }
        public string time { get; set; }

    }
}
