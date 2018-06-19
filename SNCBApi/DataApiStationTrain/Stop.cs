using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SNCBAPI
{
    public class Stop
    {
        public int id { get; set; }
        public string station { get; set; }
        public int time { get; set; }
        public int delay { get; set; }
        public string platform { get; set; }
        public string tForView { get; set; }
    }
}